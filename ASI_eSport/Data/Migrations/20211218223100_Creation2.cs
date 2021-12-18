using Microsoft.EntityFrameworkCore.Migrations;

namespace ASI_eSport.Data.Migrations
{
    public partial class Creation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championnat_Equipe_Equipe2ID",
                table: "Championnat");

            migrationBuilder.DropIndex(
                name: "IX_Championnat_Equipe2ID",
                table: "Championnat");

            migrationBuilder.DropColumn(
                name: "Equipe2ID",
                table: "Championnat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Equipe2ID",
                table: "Championnat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Championnat_Equipe2ID",
                table: "Championnat",
                column: "Equipe2ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Championnat_Equipe_Equipe2ID",
                table: "Championnat",
                column: "Equipe2ID",
                principalTable: "Equipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
