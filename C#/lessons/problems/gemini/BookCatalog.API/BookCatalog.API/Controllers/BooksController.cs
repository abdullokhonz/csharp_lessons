using BookCatalog.API.Entities;
using BookCatalog.API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookCatalogDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(BookCatalogDbContext context, ILogger<BooksController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book cannot be null.");
            }

            _logger.LogInformation("Creating a new book with ISBN {ISBN}", book.Isbn);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(book), new { id = book.Id }, book);
        }

        [HttpGet("cheap")]
        public async Task<IActionResult> GetCheapBooks([FromQuery] decimal maxPrice = 500)
        {
            var cheapBooks = await _context.Books
                .AsNoTracking()
                .Where(b => b.Price < maxPrice)
                .Select(b => new { b.Id, b.Title, b.Price })
                .ToListAsync();

            return Ok(cheapBooks);
        }
    }
}
