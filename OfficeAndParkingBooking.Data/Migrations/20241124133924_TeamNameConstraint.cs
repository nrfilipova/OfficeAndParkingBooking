using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeAndParkingBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeamNameConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Teams
                ADD CONSTRAINT UC_TeamName UNIQUE (Name);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Teams
                DROP CONSTRAINT UC_TeamName;");
        }
    }
}
