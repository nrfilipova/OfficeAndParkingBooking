namespace OfficeAndParkingBooking.Services.Common.Exceptions
{
    public class BookingTwiceException : Exception
    {
        private const string DefaultMessage = "Cannot book twice for the same day.";

        public BookingTwiceException() : base(DefaultMessage)
        {
        }

        public BookingTwiceException(string? message) : base(message)
        {
        }

        public BookingTwiceException(string message, Exception innerException)
        : base(message, innerException)
        {
        }
    }
}
