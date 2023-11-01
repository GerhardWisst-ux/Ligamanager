using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LigamanagerManagement.Api.Migrations
{
    public partial class InitLigaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ligen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Liganame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verband = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Erstaustragung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Absteiger = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ligen", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Spieltage",
                columns: table => new
                {
                    SpieltagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpieltagNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saison = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verein1_Nr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verein1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verein2_Nr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verein2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tore1_Nr = table.Column<int>(type: "int", nullable: false),
                    Tore2_Nr = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spieltage", x => x.SpieltagId);
                });

            migrationBuilder.CreateTable(
                name: "Tabellen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VereinNr = table.Column<int>(type: "int", nullable: false),
                    Verein = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Vereine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VereinNr = table.Column<int>(type: "int", nullable: false),
                    Vereinsname1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vereinsname2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stadion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fassungsvermoegen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Erfolge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gegruendet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vereine", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ligen");

            migrationBuilder.DropTable(
                name: "Saisonen");

            migrationBuilder.DropTable(
                name: "Spieltage");

            migrationBuilder.DropTable(
                name: "Tabellen");

            migrationBuilder.DropTable(
                name: "Vereine");
        }
    }
}
