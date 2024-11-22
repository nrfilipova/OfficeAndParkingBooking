namespace OfficeAndParkingBooking.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string? Model { get; set; }
        public required string RegistrationPlate { get; set; }
        public required int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
