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
            migrationBuilder.DropForeignKey(
                name: "FK_ClaseEstudiante_Clase_EstudianteId",
                table: "ClaseEstudiante");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaseEstudiante_Clase_ClaseId",
                table: "ClaseEstudiante",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaseEstudiante_Clase_ClaseId",
                table: "ClaseEstudiante");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaseEstudiante_Clase_EstudianteId",
                table: "ClaseEstudiante",
                column: "EstudianteId",
                principalTable: "Clase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
