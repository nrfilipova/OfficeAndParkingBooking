namespace OfficeAndParkingBooking.DTOs
{
    using Services.Common;
    using static Services.Common.GlobalConstants.ErrorMessage;

    using System.ComponentModel.DataAnnotations;

    public class ParkingBookingInputModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EmployeeName { get; set; }
        public string? CarModel { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string RegistrationPlate { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Arrival { get; set; }

        [DateTimeValidator(nameof(Arrival))]
        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Departure { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(1,4)] //change the hardcoding
        public int ParkingSpotId { get; set; }
    }
}
