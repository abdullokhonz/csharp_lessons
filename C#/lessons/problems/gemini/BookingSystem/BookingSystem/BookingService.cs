namespace BookingSystem
{
    public class BookingService
    {
        // Хранилище существующих броней
        private readonly List<Reservation> _reservations = new List<Reservation>();

        // Технологический перерыв (15 минут)
        private readonly TimeSpan _bufferTime = TimeSpan.FromMinutes(15);

        public bool BookTable(int tableId, DateTime start, DateTime end)
        {
            // Валидация: Бронирование не может быть в прошлом
            if (start < DateTime.Now)
            {
                Console.WriteLine("Ошибка: Нельзя бронировать на прошедшее время.");
                return false;
            }

            // Валидация: Конец должен быть после начала
            if (end <= start)
            {
                Console.WriteLine("Ошибка: Время завершения должно быть позже времени начала.");
                return false;
            }

            // Бизнес-правило: Максимальная длительность 4 часа
            if ((end - start).TotalHours > 4)
            {
                Console.WriteLine("Ошибка: Максимальное время бронирования — 4 часа.");
                return false;
            }

            // Проверка пересечений с учетом буфера 15 минут
            // Чтобы брони не "налезали" друг на друга, мы расширяем проверяемый диапазон
            DateTime requestedStartWithBuffer = start.Subtract(_bufferTime);
            DateTime requestedEndWithBuffer = end.Add(_bufferTime);

            bool isOverlapping = _reservations.Any(r =>
                r.TableId == tableId &&
                start < r.End.Add(_bufferTime) &&
                r.Start.Subtract(_bufferTime) < end);

            if (isOverlapping)
            {
                Console.WriteLine($"Ошибка: Стол №{tableId} занят на это время (или в интервале 15 мин до/после).");
                return false;
            }

            // Если всё ок — сохраняем
            _reservations.Add(new Reservation { TableId = tableId, Start = start, End = end });
            Console.WriteLine($"Успех: Стол №{tableId} забронирован на {start:HH:mm} - {end:HH:mm}");
            return true;
        }
    }
}
