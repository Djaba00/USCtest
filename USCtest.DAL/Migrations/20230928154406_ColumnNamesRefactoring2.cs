using Microsoft.EntityFrameworkCore.Migrations;

namespace USCtest.DAL.Migrations
{
    public partial class ColumnNamesRefactoring2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsColdWatherDevice",
                table: "Flats",
                newName: "IsColdWaterDevice");

            migrationBuilder.RenameColumn(
                name: "IsHotWatherDevice",
                table: "Flats",
                newName: "IsHotWaterDevice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsColdWaterDevice",
                table: "Flats",
                newName: "IsColdWatherDevice");

            migrationBuilder.RenameColumn(
                name: "IsHotWaterDevice",
                table: "Flats",
                newName: "IsHotWatherDevice");
        }
    }
}
