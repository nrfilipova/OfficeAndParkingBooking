namespace OfficeAndParkingBooking.DTOs
{
    using Services.Common;
    using static Services.Common.GlobalConstants.ErrorMessage;
    using static Services.Common.GlobalConstants.ParkingSpotConstants;

    using System.ComponentModel.DataAnnotations;

    public class ParkingBookingInputModel
    {
        public string EmployeeId { get; set; }
        public string? CarModel { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string RegistrationPlate { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Arrival { get; set; }

        [DateTimeValidator(nameof(Arrival))]
        [ParkingTime(nameof(Arrival))]
        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Departure { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(ParkingSpotStartId, ParkingSpotEndId)]
        public int ParkingSpotId { get; set; }
    }
}