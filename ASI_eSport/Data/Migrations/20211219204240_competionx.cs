using Microsoft.EntityFrameworkCore.Migrations;

namespace ASI_eSport.Data.Migrations
{
    public partial class competionx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jeu_competition_Competition_LaCompetionID",
                table: "Jeu_competition");

            migrationBuilder.DropIndex(
                name: "IX_Jeu_competition_LaCompetionID",
                table: "Jeu_competition");

            migrationBuilder.DropColumn(
                name: "LaCompetionID",
                table: "Jeu_competition");

            migrationBuilder.CreateIndex(
                name: "IX_Jeu_competition_LaCompetitionID",
                table: "Jeu_competition",
                column: "LaCompetitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jeu_competition_Competition_LaCompetitionID",
                table: "Jeu_competition",
                column: "LaCompetitionID",
                principalTable: "Competition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jeu_competition_Competition_LaCompetitionID",
                table: "Jeu_competition");

            migrationBuilder.DropIndex(
                name: "IX_Jeu_competition_LaCompetitionID",
                table: "Jeu_competition");

            migrationBuilder.AddColumn<int>(
                name: "LaCompetionID",
                table: "Jeu_competition",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jeu_competition_LaCompetionID",
                table: "Jeu_competition",
                column: "LaCompetionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jeu_competition_Competition_LaCompetionID",
                table: "Jeu_competition",
                column: "LaCompetionID",
                principalTable: "Competition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
