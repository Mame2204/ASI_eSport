using Microsoft.EntityFrameworkCore.Migrations;

namespace ASI_eSport.Data.Migrations
{
    public partial class lienjeucompet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jeu_competition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaCompetitionID = table.Column<int>(type: "int", nullable: false),
                    LaCompetionID = table.Column<int>(type: "int", nullable: true),
                    LeJeuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeu_competition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jeu_competition_Competition_LaCompetionID",
                        column: x => x.LaCompetionID,
                        principalTable: "Competition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jeu_competition_Jeu_LeJeuID",
                        column: x => x.LeJeuID,
                        principalTable: "Jeu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jeu_competition_LaCompetionID",
                table: "Jeu_competition",
                column: "LaCompetionID");

            migrationBuilder.CreateIndex(
                name: "IX_Jeu_competition_LeJeuID",
                table: "Jeu_competition",
                column: "LeJeuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jeu_competition");
        }
    }
}
