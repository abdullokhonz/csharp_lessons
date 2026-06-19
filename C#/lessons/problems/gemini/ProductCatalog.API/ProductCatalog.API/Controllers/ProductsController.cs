using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.DTOs;
using ProductCatalog.API.Entities;
using ProductCatalog.API.Infrastructure.Data;
using ProductCatalog.API.Infrastructure.Services;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly CatalogDbContext _context;
        private readonly ILogger<ProductsController> _logger;
        private readonly IDiagnosticService _diagnostic;

        // Тема 4.7, 4.8: Внедрение зависимостей (DbContext - Scoped, Logger - Singleton)
        public ProductsController(
            CatalogDbContext context,
            ILogger<ProductsController> logger,
            IDiagnosticService diagnostic)
        {
            _context = context;
            _logger = logger;
            _diagnostic = diagnostic;
        }

        // 1. GET ALL (Получение всех активных товаров)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Вызов GetAll. Диагностический ID в контроллере: {Id}", _diagnostic.InstanceId);

            // Тема 5.6: Высокооптимизированный LINQ запрос
            var products = await _context.Products
                .AsNoTracking() // Отключаем трекинг для быстрого чтения
                .Include(p => p.Category) // Загружаем связанные данные (One-to-Many)
                .Include(p => p.Tags)     // Загружаем связанные данные (Many-to-Many)
                .Select(p => new ProductResponseDto(
                    p.Id,
                    p.Name,
                    p.Price,
                    p.Category != null ? p.Category.Name : "Без категории",
                    p.Tags.Select(t => t.Name).ToList()
                ))
                .ToListAsync();

            return Ok(products);
        }

        // 2. GET BY ID 
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            // Наш глобальный QueryFilter автоматически защищает от вычитки "мягко удаленных" товаров
            var product = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                _logger.LogWarning("Товар с ID {Id} не найден или был удален.", id);
                return NotFound(new { Message = "Товар не найден." });
            }

            var response = new ProductResponseDto(
                product.Id, product.Name, product.Price,
                product.Category?.Name ?? "Нет", product.Tags.Select(t => t.Name).ToList()
            );

            return Ok(response);
        }

        // 🔥 РЕДКАЯ ФИЧА: GET ARCHIVED (Получение только мягко удаленных товаров)
        [HttpGet("archived")]
        public async Task<IActionResult> GetArchived()
        {
            // Тема 5.6: Использование .IgnoreQueryFilters() для обхода Soft Delete фильтра
            var archivedProducts = await _context.Products
                .AsNoTracking()
                .IgnoreQueryFilters() // Сбрасываем фильтр "!IsDeleted"
                .Where(p => p.IsDeleted == true)
                .ToListAsync();

            return Ok(archivedProducts);
        }

        // 3. CREATE (Создание с использованием Явной транзакции)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Price = dto.Price,
                    CategoryId = dto.CategoryId
                };

                if (dto.TagIds.Any())
                {
                    // Загружаем теги
                    var tags = await _context.Tags.Where(t => dto.TagIds.Contains(t.Id)).ToListAsync();
                    product.Tags = tags;
                }

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                _logger.LogInformation("Успешно создан товар {Name} с ID {Id}", product.Name, product.Id);

                // 🔥 ИСПРАВЛЕНИЕ: Маппим сущность в плоский ProductResponseDto, у которого нет циклов!
                // Перед этим подгрузим имя категории, если нужно, либо возьмем дефолтное
                var category = await _context.Categories.FindAsync(dto.CategoryId);

                var responseDto = new ProductResponseDto(
                    product.Id,
                    product.Name,
                    product.Price,
                    category?.Name ?? "Без категории",
                    product.Tags.Select(t => t.Name).ToList() // Берем только плоские строки имён тегов
                );

                // Возвращаем чистый DTO. Сериализатор скажет спасибо!
                return StatusCode(201, responseDto);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Ошибка при создании товара. Транзакция откатана.");
                return StatusCode(500, "Ошибка при сохранении данных.");
            }
        }

        // 4. UPDATE (Обновление Many-to-Many связей)
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto dto)
        {
            // Ищем товар, подгружая текущие теги, чтобы EF Core смог сделать правильный Update связей
            var product = await _context.Products.Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;

            // Обновляем теги: очищаем старые, добавляем новые
            product.Tags.Clear();
            if (dto.TagIds.Any())
            {
                var tags = await _context.Tags.Where(t => dto.TagIds.Contains(t.Id)).ToListAsync();
                product.Tags = tags;
            }

            await _context.SaveChangesAsync();
            return NoContent(); // 204 No Content - стандарт для PUT обновлений
        }

        // 5. SOFT DELETE (Мягкое удаление)
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            // Вместо _context.Products.Remove() мы просто меняем флаг!
            product.IsDeleted = true;

            await _context.SaveChangesAsync();

            _logger.LogWarning("Товар {Id} был переведен в статус 'Удален' (Soft Delete).", id);
            return NoContent();
        }

        // 6. HARD DELETE (Окончательное физическое удаление из БД)
        [HttpDelete("{id:guid}/hard")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            // Чтобы найти запись для жесткого удаления, сбрасываем глобальный QueryFilter
            var product = await _context.Products.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            // Физическое удаление строки из таблицы базы данных
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
