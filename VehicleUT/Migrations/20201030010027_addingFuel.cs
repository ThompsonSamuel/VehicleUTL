using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleUT.Migrations
{
    public partial class addingFuel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "fuelUsed",
                table: "Vehicle",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "milesGone",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fuelUsed",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "milesGone",
                table: "Vehicle");
        }
    }
}
