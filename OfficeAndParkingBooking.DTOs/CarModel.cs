namespace OfficeAndParkingBooking.DTOs
{
    using static Services.Common.GlobalConstants.ErrorMessage;

    using System.ComponentModel.DataAnnotations;

    public class CarModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
