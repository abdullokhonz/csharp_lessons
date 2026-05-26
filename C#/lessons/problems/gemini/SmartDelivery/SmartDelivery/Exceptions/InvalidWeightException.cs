namespace SmartDelivery.Exceptions
{
    public class InvalidWeightException : Exception
    {
        public InvalidWeightException() { }

        public InvalidWeightException(string message) : base(message) { }

        public InvalidWeightException(string message, Exception innerException) : base(message, innerException) { }
    }
}
