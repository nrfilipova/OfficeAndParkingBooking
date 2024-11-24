namespace OfficeAndParkingBooking.Data
{
    using Models;
    using Seeding;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class OfficeAndParkingBookingDbContext : IdentityDbContext<Employee>
    {
        protected OfficeAndParkingBookingDbContext()
        {
        }

        public OfficeAndParkingBookingDbContext(DbContextOptions<OfficeAndParkingBookingDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<ParkingSpot> ParkingSpots { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<OfficeBooking> OfficeBooking { get; set; } = null!;
        public DbSet<ParkingBooking> ParkingBooking { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new ParkingSpotConfiguration());
        }
    }
}
