using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeAndParkingBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class ParkingBookingDateCheckConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE ParkingBooking
         ADD CONSTRAINT CHK_ParkingBookingDate CHECK (Departure > Arrival);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE ParkingBooking
         DROP CONSTRAINT CHK_ParkingBookingDate;");
        }
    }
}
