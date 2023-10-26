using Microsoft.EntityFrameworkCore.Migrations;

namespace LigaManagerManagement.Api.Migrations
{
    public partial class ChangesSpieltage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Verein",
                table: "Spieltage",
                newName: "Verein2");

            migrationBuilder.AddColumn<string>(
                name: "Verein1",
                table: "Spieltage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verein1",
                table: "Spieltage");

            migrationBuilder.RenameColumn(
                name: "Verein2",
                table: "Spieltage",
                newName: "Verein");
        }
    }
}
