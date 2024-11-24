﻿namespace OfficeAndParkingBooking.Data.Models
{
    using static Services.Common.GlobalConstants.EmployeeConstants;

    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(EmployeeNameMaxLenght)]
        public required string FullName { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; } = null!;
        public ICollection<OfficeBooking> OfficeBookings { get; set; } = new List<OfficeBooking>();
        public ICollection<ParkingBooking> ParkingBookings { get; set; } = new List<ParkingBooking>();
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
