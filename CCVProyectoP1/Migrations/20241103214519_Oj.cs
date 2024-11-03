using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class Oj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteClases_Clase_ClaseId",
                table: "EstudianteClases");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteClases_Estudiante_EstudianteId",
                table: "EstudianteClases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstudianteClases",
                table: "EstudianteClases");

            migrationBuilder.RenameTable(
                name: "EstudianteClases",
                newName: "ClaseEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_EstudianteClases_EstudianteId",
                table: "ClaseEstudiante",
                newName: "IX_ClaseEstudiante_EstudianteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaseEstudiante",
                table: "ClaseEstudiante",
                columns: new[] { "ClaseId", "EstudianteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase",
                column: "IdProfesor",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaseEstudiante_Clase_ClaseId",
                table: "ClaseEstudiante",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaseEstudiante_Estudiante_EstudianteId",
                table: "ClaseEstudiante",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaseEstudiante_Clase_ClaseId",
                table: "ClaseEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaseEstudiante_Estudiante_EstudianteId",
                table: "ClaseEstudiante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaseEstudiante",
                table: "ClaseEstudiante");

            migrationBuilder.RenameTable(
                name: "ClaseEstudiante",
                newName: "EstudianteClases");

            migrationBuilder.RenameIndex(
                name: "IX_ClaseEstudiante_EstudianteId",
                table: "EstudianteClases",
                newName: "IX_EstudianteClases_EstudianteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstudianteClases",
                table: "EstudianteClases",
                columns: new[] { "ClaseId", "EstudianteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase",
                column: "IdProfesor",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteClases_Clase_ClaseId",
                table: "EstudianteClases",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteClases_Estudiante_EstudianteId",
                table: "EstudianteClases",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
