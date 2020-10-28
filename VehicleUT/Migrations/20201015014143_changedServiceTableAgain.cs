using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleUT.Migrations
{
    public partial class changedServiceTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeService",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "Dates",
                table: "Service",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Service",
                newName: "Dates");

            migrationBuilder.AddColumn<int>(
                name: "TypeService",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
