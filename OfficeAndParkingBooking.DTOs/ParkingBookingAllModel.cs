namespace OfficeAndParkingBooking.DTOs
{
    using static Services.Common.GlobalConstants.ErrorMessage;

    using System.ComponentModel.DataAnnotations;

    public class ParkingBookingAllModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Arrival { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Departure { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int ParkingSpotNumber { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EmployeeName { get; set; } = string.Empty;
    }
}
