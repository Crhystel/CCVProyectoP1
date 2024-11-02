using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class Otra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Clase_ClaseId",
                table: "Estudiante");

            migrationBuilder.AlterColumn<int>(
                name: "ClaseId",
                table: "Estudiante",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Clase_ClaseId",
                table: "Estudiante",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Clase_ClaseId",
                table: "Estudiante");

            migrationBuilder.AlterColumn<int>(
                name: "ClaseId",
                table: "Estudiante",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Clase_ClaseId",
                table: "Estudiante",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
