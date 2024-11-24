namespace OfficeAndParkingBooking.Data.Models
{
    using static Services.Common.GlobalConstants.CarConstants;

    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string? Model { get; set; }

        [StringLength(CarRegistrationPlateMaxLenght)]
        [RegularExpression(CarRegistrationPlatePattern)]
        public required string RegistrationPlate { get; set; }
        public required int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
