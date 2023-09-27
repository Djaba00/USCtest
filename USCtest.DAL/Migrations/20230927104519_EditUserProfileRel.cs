using Microsoft.EntityFrameworkCore.Migrations;

namespace USCtest.DAL.Migrations
{
    public partial class EditUserProfileRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxes_Flats_FlatId1",
                table: "Taxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Taxes_FlatId1",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "FlatId1",
                table: "Taxes");

            migrationBuilder.AlterColumn<int>(
                name: "FlatId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlatId",
                table: "Taxes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Registrations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApplicationUserId",
                table: "Users",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_FlatId",
                table: "Taxes",
                column: "FlatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxes_Flats_FlatId",
                table: "Taxes",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_ApplicationUserId",
                table: "Users",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxes_Flats_FlatId",
                table: "Taxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_ApplicationUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApplicationUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Taxes_FlatId",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "FlatId",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "FlatId",
                table: "Taxes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "FlatId1",
                table: "Taxes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Registrations",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_FlatId1",
                table: "Taxes",
                column: "FlatId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxes_Flats_FlatId1",
                table: "Taxes",
                column: "FlatId1",
                principalTable: "Flats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_Id",
                table: "Users",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
