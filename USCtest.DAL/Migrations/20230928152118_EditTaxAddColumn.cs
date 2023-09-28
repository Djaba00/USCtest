using Microsoft.EntityFrameworkCore.Migrations;

namespace USCtest.DAL.Migrations
{
    public partial class EditTaxAddColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Residents",
                table: "Taxes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Residents",
                table: "Taxes");
        }
    }
}
