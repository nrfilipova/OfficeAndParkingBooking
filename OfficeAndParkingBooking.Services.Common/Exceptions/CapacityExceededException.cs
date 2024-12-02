namespace OfficeAndParkingBooking.Services.Common.Exceptions
{
    public class CapacityExceededException : Exception
    {
        private const string DefaultMessage = "Exceeded room capacity.";

        public CapacityExceededException() : base(DefaultMessage)
        {
        }

        public CapacityExceededException(string? message) : base(message)
        {
        }

        public CapacityExceededException(string message, Exception innerException)
        : base(message, innerException)
        {
        }
    }
}
