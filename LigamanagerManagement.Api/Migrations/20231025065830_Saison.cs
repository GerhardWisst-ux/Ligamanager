using Microsoft.EntityFrameworkCore.Migrations;

namespace LigaManagerManagement.Api.Migrations
{
    public partial class Saison : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saisonen",
                columns: table => new
                {
                    SaisonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saisonname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LigaID = table.Column<int>(type: "int", nullable: false),
                    Liganame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktuell = table.Column<bool>(type: "bit", nullable: false),
                    Abgeschlossen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saisonen", x => x.SaisonID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saisonen");
        }
    }
}
