using Microsoft.EntityFrameworkCore.Migrations;

namespace USCtest.WebClient.Migrations
{
    public partial class EditTax1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ColdWatherVolume",
                table: "Taxes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ElectricPowerVolume",
                table: "Taxes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HotWatherVolume",
                table: "Taxes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColdWatherVolume",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "ElectricPowerVolume",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "HotWatherVolume",
                table: "Taxes");
        }
    }
}
