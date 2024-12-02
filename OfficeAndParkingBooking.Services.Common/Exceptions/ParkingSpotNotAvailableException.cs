namespace OfficeAndParkingBooking.Services.Common.Exceptions
{
    public class ParkingSpotNotAvailableException : Exception
    {

        private const string DefaultMessage = "Parking spot is not available.";

        public ParkingSpotNotAvailableException() : base(DefaultMessage)
        {
        }

        public ParkingSpotNotAvailableException(string? message) : base(message)
        {
        }

        public ParkingSpotNotAvailableException(string message, Exception innerException)
        : base(message, innerException)
        {
        }
    }
}
