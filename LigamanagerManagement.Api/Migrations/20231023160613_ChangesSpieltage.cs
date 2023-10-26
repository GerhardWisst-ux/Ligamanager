using Microsoft.EntityFrameworkCore.Migrations;

namespace LigaManagerManagement.Api.Migrations
{
    public partial class ChangesSpieltage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spieltage_Vereine_VereinId",
                table: "Spieltage");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabellen_Vereine_VereinId",
                table: "Tabellen");

            migrationBuilder.DropIndex(
                name: "IX_Tabellen_VereinId",
                table: "Tabellen");

            migrationBuilder.DropIndex(
                name: "IX_Spieltage_VereinId",
                table: "Spieltage");

            migrationBuilder.DropColumn(
                name: "VereinId",
                table: "Tabellen");

            migrationBuilder.DropColumn(
                name: "VereinId",
                table: "Spieltage");

            migrationBuilder.AddColumn<string>(
                name: "Verein",
                table: "Tabellen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Verein",
                table: "Spieltage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verein",
                table: "Tabellen");

            migrationBuilder.DropColumn(
                name: "Verein",
                table: "Spieltage");

            migrationBuilder.AddColumn<int>(
                name: "VereinId",
                table: "Tabellen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VereinId",
                table: "Spieltage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tabellen_VereinId",
                table: "Tabellen",
                column: "VereinId");

            migrationBuilder.CreateIndex(
                name: "IX_Spieltage_VereinId",
                table: "Spieltage",
                column: "VereinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spieltage_Vereine_VereinId",
                table: "Spieltage",
                column: "VereinId",
                principalTable: "Vereine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabellen_Vereine_VereinId",
                table: "Tabellen",
                column: "VereinId",
                principalTable: "Vereine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
