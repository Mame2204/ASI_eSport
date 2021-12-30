using Microsoft.EntityFrameworkCore.Migrations;

namespace ASI_eSport.Data.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JeuChoisiID",
                table: "Equipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_JeuChoisiID",
                table: "Equipe",
                column: "JeuChoisiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Jeu_JeuChoisiID",
                table: "Equipe",
                column: "JeuChoisiID",
                principalTable: "Jeu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_Jeu_JeuChoisiID",
                table: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_JeuChoisiID",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "JeuChoisiID",
                table: "Equipe");
        }
    }
}
