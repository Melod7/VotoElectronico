using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotoElectronico.MVC.Migrations
{
    /// <inheritdoc />
    public partial class Votos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CedulaVotante",
                table: "Votos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VotanteId",
                table: "Votos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Votos_PartidoId",
                table: "Votos",
                column: "PartidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Partidos_PartidoId",
                table: "Votos",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Partidos_PartidoId",
                table: "Votos");

            migrationBuilder.DropIndex(
                name: "IX_Votos_PartidoId",
                table: "Votos");

            migrationBuilder.DropColumn(
                name: "CedulaVotante",
                table: "Votos");

            migrationBuilder.DropColumn(
                name: "VotanteId",
                table: "Votos");
        }
    }
}
