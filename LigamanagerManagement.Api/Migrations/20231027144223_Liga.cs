using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LigaManagerManagement.Api.Migrations
{
    public partial class Liga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ligen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verband = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Erstaustragung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Absteiger = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ligen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ligen");
        }
    }
}
