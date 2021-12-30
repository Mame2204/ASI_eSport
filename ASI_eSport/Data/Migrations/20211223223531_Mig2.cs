using Microsoft.EntityFrameworkCore.Migrations;

namespace ASI_eSport.Data.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipeID",
                table: "Equipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contenir",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeLicencieID = table.Column<int>(type: "int", nullable: false),
                    LEquipeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contenir", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contenir_Equipe_LEquipeID",
                        column: x => x.LEquipeID,
                        principalTable: "Equipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contenir_Licencie_LeLicencieID",
                        column: x => x.LeLicencieID,
                        principalTable: "Licencie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_EquipeID",
                table: "Equipe",
                column: "EquipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Contenir_LeLicencieID",
                table: "Contenir",
                column: "LeLicencieID");

            migrationBuilder.CreateIndex(
                name: "IX_Contenir_LEquipeID",
                table: "Contenir",
                column: "LEquipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Equipe_EquipeID",
                table: "Equipe",
                column: "EquipeID",
                principalTable: "Equipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_Equipe_EquipeID",
                table: "Equipe");

            migrationBuilder.DropTable(
                name: "Contenir");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_EquipeID",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "EquipeID",
                table: "Equipe");
        }
    }
}
