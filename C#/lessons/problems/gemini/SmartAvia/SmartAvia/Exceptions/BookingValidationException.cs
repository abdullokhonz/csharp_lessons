namespace SmartAvia.Exceptions
{
    public class BookingValidationException : Exception
    {
        public BookingValidationException() { }

        public BookingValidationException(string message) : base(message) { }

        public BookingValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
