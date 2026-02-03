using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VotoElectronico.MVC.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaCandidatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidatoId",
                table: "Votos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EleccionId",
                table: "Partidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Presidente = table.Column<string>(type: "text", nullable: false),
                    Vicepresidente = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    PartidoId = table.Column<int>(type: "integer", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatos_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eleccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activa = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleccion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votos_CandidatoId",
                table: "Votos",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_VotanteId",
                table: "Votos",
                column: "VotanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EleccionId",
                table: "Partidos",
                column: "EleccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_PartidoId",
                table: "Candidatos",
                column: "PartidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Eleccion_EleccionId",
                table: "Partidos",
                column: "EleccionId",
                principalTable: "Eleccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Candidatos_CandidatoId",
                table: "Votos",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Votantes_VotanteId",
                table: "Votos",
                column: "VotanteId",
                principalTable: "Votantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Eleccion_EleccionId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Candidatos_CandidatoId",
                table: "Votos");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Votantes_VotanteId",
                table: "Votos");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Eleccion");

            migrationBuilder.DropIndex(
                name: "IX_Votos_CandidatoId",
                table: "Votos");

            migrationBuilder.DropIndex(
                name: "IX_Votos_VotanteId",
                table: "Votos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_EleccionId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "CandidatoId",
                table: "Votos");

            migrationBuilder.DropColumn(
                name: "EleccionId",
                table: "Partidos");
        }
    }
}
