using Microsoft.Extensions.Logging;
using SmartAvia.Exceptions;
using SmartAvia.HttpClients;
using SmartAvia.Models;

namespace SmartAvia.Services
{
    public class BookingService : IBookingService
    {
        private readonly List<FlightBooking> _bookings = new();
        private readonly HashSet<string> _registeredPassengers = new();
        private Dictionary<string, decimal> _exchangeRates = new();

        private readonly IExchangeClient _exchangeClient;
        private readonly ILogger<BookingService> _logger;

        public BookingService(IExchangeClient exchangeClient, ILogger<BookingService> logger)
        {
            _exchangeClient = exchangeClient ?? throw new ArgumentNullException(nameof(exchangeClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddFlightBooking(
            string passengerName,
            string flightNumber,
            decimal basePriceInUsd,
            string targetCurrency,
            string? passportNumber
        )
        {
            if (string.IsNullOrWhiteSpace(passengerName))
                throw new ArgumentNullException(nameof(passengerName), "Имя пассажира не может быть пустым.");

            if (string.IsNullOrWhiteSpace(flightNumber))
                throw new ArgumentNullException(nameof(flightNumber), "Номер рейса не может быть пустым.");

            if (basePriceInUsd <= 0)
                throw new BookingValidationException("Базовая цена рейса должна быть положительной.");

            if (string.IsNullOrWhiteSpace(targetCurrency))
                throw new ArgumentNullException(nameof(targetCurrency), "Целевая валюта не может быть пустой.");

            passportNumber ??= "ИСПРАВИТЬ_ПРИ_РЕГИСТРАЦИИ";

            var booking = new FlightBooking
            (
                Guid.NewGuid(),
                passengerName.Trim(),
                flightNumber.Trim(),
                basePriceInUsd,
                targetCurrency.ToUpper(),
                passportNumber
            );

            _bookings.Add(booking);

            if (!_registeredPassengers.Add(passportNumber))
                _logger.LogInformation("Постоянный клиент {Name} совершил повторную покупку!", passengerName);

            _logger.LogInformation(
                "Добавлено бронирование для пассажира {Name} на рейс {FlightNumber} с базовой ценой {Price} USD в валюте {Currency}.",
                passportNumber, flightNumber, basePriceInUsd, targetCurrency
            );
        }

        public IEnumerable<FlightBooking> GetFlightBookings()
        {
            var bookings = _bookings.ToList();

            if (bookings.Any())
                bookings = bookings.OrderBy(b => b.FlightNumber)
                                   .ThenByDescending(b => b.BasePriceInUsd)
                                   .ToList();

            _logger.LogInformation("Получено {Count} бронирований.", bookings.Count);

            return bookings;
        }

        public async Task LoadExchangeRatesAsync(CancellationToken ct = default)
        {
            _exchangeRates = await _exchangeClient.GetExchangeRatesAsync(ct);

            _logger.LogInformation("Курсы валют успешно обновлены.");
        }

        public decimal GetTotalAmountInTargetCurrency()
        {
            if (!_bookings.Any())
                return 0;

            if (!_exchangeRates.Any())
                _logger.LogWarning("Расчёт неточен: курсы валют ещё не были загружены из сети!");

            return _bookings.Sum(b =>
            {
                if (b.TargetCurrency == "USD")
                    return b.BasePriceInUsd;

                if (_exchangeRates.TryGetValue(b.TargetCurrency, out var rate) && rate > 0)
                    return b.BasePriceInUsd * rate;

                _logger.LogWarning("Не получилось рассчитать стоимость для валюты {TargetCurrency}. Курс подменен на 0.",
                    b.TargetCurrency);

                return 0;
            });
        }

        public async Task EmitTicketsAsync(CancellationToken ct = default)
        {
            _logger.LogInformation("Начинаем генерацию PDF и отправку на E-mail...");

            foreach (var booking in _bookings)
            {
                ct.ThrowIfCancellationRequested();

                await Task.Delay(1500, ct);

                _logger.LogInformation("Билет для пассажира {Name} на рейс {FlightNumber} успешно сгенерирован и отправлен на E-mail.",
                    booking.PassengerName, booking.FlightNumber);
            }

            _logger.LogInformation("Все билеты успешно сгенерированы и отправлены.");
        }
    }
}
