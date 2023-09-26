using Microsoft.EntityFrameworkCore.Migrations;

namespace USCtest.DAL.Migrations
{
    public partial class AddSummaryTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SummaryCost",
                table: "Taxes",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SummaryCost",
                table: "Taxes");
        }
    }
}
