namespace OfficeAndParkingBooking.DTOs
{
    using Services.Common;
    using static Services.Common.GlobalConstants.ErrorMessage;

    using System.ComponentModel.DataAnnotations;

    public class OfficeBookingInputModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [DateValidator]
        public DateOnly Date { get; set; }
        public string? Notes { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string RoomNumber { get; set; }
    }
}