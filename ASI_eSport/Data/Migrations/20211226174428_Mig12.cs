using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASI_eSport.Data.Migrations
{
    public partial class Mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rencontre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRencontre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipeRencontreeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rencontre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rencontre_Equipe_EquipeRencontreeID",
                        column: x => x.EquipeRencontreeID,
                        principalTable: "Equipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rencontre_EquipeRencontreeID",
                table: "Rencontre",
                column: "EquipeRencontreeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rencontre");
        }
    }
}
