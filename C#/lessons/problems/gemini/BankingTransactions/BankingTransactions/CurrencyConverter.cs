namespace BankingTransactions
{
    public static class CurrencyConverter
    {
        public static decimal GetExchangeRate(Currency from, Currency to)
        {
            if (from == to) return 1.0m;
            // Упрощенный пример: 1 USD = 90 RUB, 1 RUB = 0.011 USD
            if (from == Currency.USD && to == Currency.RUB) return 90.0m;
            if (from == Currency.RUB && to == Currency.USD) return 0.011m;
            return 1.0m; // По умолчанию 1 к 1
        }
    }
}
