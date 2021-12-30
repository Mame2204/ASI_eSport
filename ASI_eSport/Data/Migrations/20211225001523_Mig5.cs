using Microsoft.EntityFrameworkCore.Migrations;

namespace ASI_eSport.Data.Migrations
{
    public partial class Mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_Equipe_EquipeID",
                table: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_EquipeID",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "EquipeID",
                table: "Equipe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipeID",
                table: "Equipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_EquipeID",
                table: "Equipe",
                column: "EquipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Equipe_EquipeID",
                table: "Equipe",
                column: "EquipeID",
                principalTable: "Equipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
