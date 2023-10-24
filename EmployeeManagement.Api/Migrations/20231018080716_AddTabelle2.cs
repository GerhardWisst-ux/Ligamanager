using Microsoft.EntityFrameworkCore.Migrations;

namespace LigaManagerManagement.Api.Migrations
{
    public partial class AddTabelle2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabellen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VereinNr = table.Column<int>(type: "int", nullable: false),
                    Tab_Sai_Id = table.Column<int>(type: "int", nullable: false),
                    Liga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tab_Lig_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platz = table.Column<int>(type: "int", nullable: false),
                    Spiele = table.Column<int>(type: "int", nullable: false),
                    Punkte = table.Column<int>(type: "int", nullable: false),
                    Gewonnen = table.Column<int>(type: "int", nullable: false),
                    Untentschieden = table.Column<int>(type: "int", nullable: false),
                    Verloren = table.Column<int>(type: "int", nullable: false),
                    TorePlus = table.Column<int>(type: "int", nullable: false),
                    ToreMinus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabellen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabellen");
        }
    }
}
