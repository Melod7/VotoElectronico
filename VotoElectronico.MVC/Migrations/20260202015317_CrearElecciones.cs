using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotoElectronico.MVC.Migrations
{
    /// <inheritdoc />
    public partial class CrearElecciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Eleccion_EleccionId",
                table: "Partidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eleccion",
                table: "Eleccion");

            migrationBuilder.RenameTable(
                name: "Eleccion",
                newName: "Elecciones");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Elecciones",
                newName: "FechaInicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Elecciones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elecciones",
                table: "Elecciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Elecciones_EleccionId",
                table: "Partidos",
                column: "EleccionId",
                principalTable: "Elecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Elecciones_EleccionId",
                table: "Partidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Elecciones",
                table: "Elecciones");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Elecciones");

            migrationBuilder.RenameTable(
                name: "Elecciones",
                newName: "Eleccion");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Eleccion",
                newName: "Fecha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eleccion",
                table: "Eleccion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Eleccion_EleccionId",
                table: "Partidos",
                column: "EleccionId",
                principalTable: "Eleccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
