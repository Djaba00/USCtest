using Microsoft.EntityFrameworkCore.Migrations;

namespace USCtest.DAL.Migrations
{
    public partial class ColumnNamesRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotWaterThermalEnergyVolume",
                table: "Taxes",
                newName: "HotWaterThermalEnergyVolume");

            migrationBuilder.RenameColumn(
                name: "HotWaterThermalEnergyCost",
                table: "Taxes",
                newName: "HotWaterThermalEnergyCost");

            migrationBuilder.RenameColumn(
                name: "HotWaterHeatVolume",
                table: "Taxes",
                newName: "HotWaterHeatVolume");

            migrationBuilder.RenameColumn(
                name: "HotWaterHeatCost",
                table: "Taxes",
                newName: "HotWaterHeatCost");

            migrationBuilder.RenameColumn(
                name: "ColdWaterVolume",
                table: "Taxes",
                newName: "ColdWaterVolume");

            migrationBuilder.RenameColumn(
                name: "ColdWaterCost",
                table: "Taxes",
                newName: "ColdWaterCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotWaterThermalEnergyVolume",
                table: "Taxes",
                newName: "HotWaterThermalEnergyVolume");

            migrationBuilder.RenameColumn(
                name: "HotWaterThermalEnergyCost",
                table: "Taxes",
                newName: "HotWaterThermalEnergyCost");

            migrationBuilder.RenameColumn(
                name: "HotWaterHeatVolume",
                table: "Taxes",
                newName: "HotWaterHeatVolume");

            migrationBuilder.RenameColumn(
                name: "HotWaterHeatCost",
                table: "Taxes",
                newName: "HotWaterHeatCost");

            migrationBuilder.RenameColumn(
                name: "ColdWaterVolume",
                table: "Taxes",
                newName: "ColdWaterVolume");

            migrationBuilder.RenameColumn(
                name: "ColdWaterCost",
                table: "Taxes",
                newName: "ColdWaterCost");
        }
    }
}
