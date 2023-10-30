using Microsoft.EntityFrameworkCore.Migrations;

namespace LigaManagerManagement.Api.Migrations
{
    public partial class Vereine2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Erfolge",
                table: "Vereine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fassungsvermoegen",
                table: "Vereine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gegruendet",
                table: "Vereine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Stadion",
                table: "Vereine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Erfolge",
                table: "Vereine");

            migrationBuilder.DropColumn(
                name: "Fassungsvermoegen",
                table: "Vereine");

            migrationBuilder.DropColumn(
                name: "Gegruendet",
                table: "Vereine");

            migrationBuilder.DropColumn(
                name: "Stadion",
                table: "Vereine");
        }
    }
}
