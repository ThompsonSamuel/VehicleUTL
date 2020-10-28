using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleUT.Migrations
{
    public partial class changedServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Incident",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "ServiceOrRepair",
                table: "Service",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "TypeService",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeService",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Service",
                newName: "ServiceOrRepair");

            migrationBuilder.AddColumn<string>(
                name: "Incident",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
