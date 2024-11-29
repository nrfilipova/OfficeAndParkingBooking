namespace OfficeAndParkingBooking.DTOs
{
    using Services.Common;
    using static Services.Common.GlobalConstants.ErrorMessage;
    using static Services.Common.GlobalConstants.ParkingSpotConstants;

    using System.ComponentModel.DataAnnotations;

    public class ParkingBookingInputModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string RegistrationPlate { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Arrival { get; set; }

        [DateTimeValidator(nameof(Arrival))]
        [ParkingTime(nameof(Arrival))]
        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Departure { get; set; }

        [Range(ParkingSpotStartId, ParkingSpotEndId)]
        public int SpotId { get; set; }
    }
}