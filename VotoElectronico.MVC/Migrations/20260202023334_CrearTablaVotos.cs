using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotoElectronico.MVC.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaVotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Presidente",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "Vicepresidente",
                table: "Candidatos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Presidente",
                table: "Candidatos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vicepresidente",
                table: "Candidatos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
