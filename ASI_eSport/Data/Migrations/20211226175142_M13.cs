using Microsoft.EntityFrameworkCore.Migrations;

namespace ASI_eSport.Data.Migrations
{
    public partial class M13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rencontre_Equipe_EquipeRencontreeID",
                table: "Rencontre");

            migrationBuilder.RenameColumn(
                name: "EquipeRencontreeID",
                table: "Rencontre",
                newName: "CompetitionconcerneeID");

            migrationBuilder.RenameIndex(
                name: "IX_Rencontre_EquipeRencontreeID",
                table: "Rencontre",
                newName: "IX_Rencontre_CompetitionconcerneeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rencontre_Competition_CompetitionconcerneeID",
                table: "Rencontre",
                column: "CompetitionconcerneeID",
                principalTable: "Competition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rencontre_Competition_CompetitionconcerneeID",
                table: "Rencontre");

            migrationBuilder.RenameColumn(
                name: "CompetitionconcerneeID",
                table: "Rencontre",
                newName: "EquipeRencontreeID");

            migrationBuilder.RenameIndex(
                name: "IX_Rencontre_CompetitionconcerneeID",
                table: "Rencontre",
                newName: "IX_Rencontre_EquipeRencontreeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rencontre_Equipe_EquipeRencontreeID",
                table: "Rencontre",
                column: "EquipeRencontreeID",
                principalTable: "Equipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
