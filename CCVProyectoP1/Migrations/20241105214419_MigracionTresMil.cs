using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class MigracionTresMil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grado",
                table: "Clase");

            migrationBuilder.AddColumn<int>(
                name: "Grado",
                table: "ClaseEstudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grado",
                table: "ClaseEstudiante");

            migrationBuilder.AddColumn<int>(
                name: "Grado",
                table: "Clase",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
