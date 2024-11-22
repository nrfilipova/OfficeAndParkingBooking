namespace OfficeAndParkingBooking.Data.Seeding
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        private IEnumerable<Room> rooms =
        [
            new Room
            {
                Id = 1,
                Capacity = 8,
                Number = 403,
            },
            new Room
            {
                Id = 2,
                Capacity = 8,
                Number = 404,
            }
        ];

        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(rooms);
        }
    }
}