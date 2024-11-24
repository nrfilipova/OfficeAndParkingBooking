namespace OfficeAndParkingBooking.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ParkingBooking
    {
        [Key]
        public int Id { get; set; }
        public required DateTime Arrival { get; set; }
        public required DateTime Departure { get; set; }
        public int ParkingSpotId { get; set; }
        public ParkingSpot ParkingSpot { get; set; } = null!;
        public required string EmployeeId { get; set; }
        public Employee Employees { get; set; } = null!;
    }
}
