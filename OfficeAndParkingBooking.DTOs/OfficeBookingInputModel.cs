namespace OfficeAndParkingBooking.DTOs
{
    using static Services.Common.GlobalConstants.ErrorMessage;

    using System.ComponentModel.DataAnnotations;

    public class OfficeBookingInputModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Date { get; set; }
        public string? Notes { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EmployeeTeam { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EmployeeName { get; set; }
    }
}
