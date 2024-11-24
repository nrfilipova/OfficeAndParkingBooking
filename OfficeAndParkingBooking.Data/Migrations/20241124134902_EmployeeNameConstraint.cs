using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeAndParkingBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeNameConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Employees
                ADD CONSTRAINT UC_EmployeeName UNIQUE (FullName);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Employees
                DROP CONSTRAINT UC_EmployeeName;");
        }
    }
}