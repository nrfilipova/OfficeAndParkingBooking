namespace OfficeAndParkingBooking.DTOs
{
    using static Services.Common.GlobalConstants.ErrorMessage;

    using System.ComponentModel.DataAnnotations;

    public class OfficeBookingAllModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateOnly Date { get; set; }

        public string? Notes { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EmployeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EmployeeTeam { get; set; } = string.Empty;
    }
}
