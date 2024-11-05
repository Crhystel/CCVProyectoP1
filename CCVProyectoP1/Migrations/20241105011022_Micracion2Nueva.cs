using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class Micracion2Nueva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Materia",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Clase");

            migrationBuilder.AddColumn<int>(
                name: "ClaseNombre",
                table: "Clase",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaseNombre",
                table: "Clase");

            migrationBuilder.AddColumn<string>(
                name: "Materia",
                table: "Profesor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Clase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
