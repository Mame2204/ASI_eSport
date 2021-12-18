using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASI_eSport.Data.Migrations
{
    public partial class Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleCompetion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEquipe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jeu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleJeu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Licencie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naissance = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Championnat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipe1ID = table.Column<int>(type: "int", nullable: false),
                    Equipe2ID = table.Column<int>(type: "int", nullable: false),
                    DateJeu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeFormule = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championnat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Championnat_Equipe_Equipe1ID",
                        column: x => x.Equipe1ID,
                        principalTable: "Equipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Championnat_Equipe_Equipe2ID",
                        column: x => x.Equipe2ID,
                        principalTable: "Equipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championnat_Equipe1ID",
                table: "Championnat",
                column: "Equipe1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Championnat_Equipe2ID",
                table: "Championnat",
                column: "Equipe2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Championnat");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Jeu");

            migrationBuilder.DropTable(
                name: "Licencie");

            migrationBuilder.DropTable(
                name: "Equipe");
        }
    }
}
