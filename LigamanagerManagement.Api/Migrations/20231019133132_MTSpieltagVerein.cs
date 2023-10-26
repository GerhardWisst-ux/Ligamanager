using Microsoft.EntityFrameworkCore.Migrations;

namespace LigaManagerManagement.Api.Migrations
{
    public partial class MTSpieltagVerein : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vereinsname",
                table: "Vereine",
                newName: "Vereinsname2");

            migrationBuilder.AddColumn<string>(
                name: "Vereinsname1",
                table: "Vereine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vereinsname1",
                table: "Vereine");

            migrationBuilder.RenameColumn(
                name: "Vereinsname2",
                table: "Vereine",
                newName: "Vereinsname");
        }
    }
}
