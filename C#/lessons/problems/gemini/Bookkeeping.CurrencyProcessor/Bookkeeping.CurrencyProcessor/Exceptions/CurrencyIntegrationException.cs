namespace Bookkeeping.CurrencyProcessor.Exceptions
{
    public class CurrencyIntegrationException : Exception
    {
        public CurrencyIntegrationException(string message) : base(message) { }
        public CurrencyIntegrationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
