namespace OfficeAndParkingBooking.DTOs
{
    using static Services.Common.GlobalConstants.ErrorMessage;

    using System.ComponentModel.DataAnnotations;

    public class ParkingSpotsModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Number { get; set; }
    }
}
