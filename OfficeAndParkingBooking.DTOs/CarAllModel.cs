namespace OfficeAndParkingBooking.DTOs
{
    using Data.Models;

    public class CarAllModel
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public required string RegistrationPlate { get; set; }
        public required int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
