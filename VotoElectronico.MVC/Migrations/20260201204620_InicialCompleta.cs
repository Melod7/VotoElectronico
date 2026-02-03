using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotoElectronico.MVC.Migrations
{
    /// <inheritdoc />
    public partial class InicialCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CedulaVotante",
                table: "Votos",
                newName: "Cedula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "Votos",
                newName: "CedulaVotante");
        }
    }
}
