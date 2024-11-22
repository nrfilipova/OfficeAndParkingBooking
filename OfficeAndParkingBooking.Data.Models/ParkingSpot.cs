namespace OfficeAndParkingBooking.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ParkingSpot
    {
        [Key]
        public int Id { get; set; }
        public required int Number { get; set; }
        ICollection<ParkingBooking> Bookings { get; set; } = new List<ParkingBooking>();
    }
}
