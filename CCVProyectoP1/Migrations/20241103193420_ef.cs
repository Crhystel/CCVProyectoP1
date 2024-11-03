using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class ef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase");

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase",
                column: "IdProfesor",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase");

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase",
                column: "IdProfesor",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
