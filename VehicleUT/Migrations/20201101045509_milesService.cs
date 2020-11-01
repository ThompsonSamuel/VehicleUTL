using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleUT.Migrations
{
    public partial class milesService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "fuelUsed",
                table: "Vehicle",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "serviceMiles",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "serviceMiles",
                table: "Service");

            migrationBuilder.AlterColumn<double>(
                name: "fuelUsed",
                table: "Vehicle",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
