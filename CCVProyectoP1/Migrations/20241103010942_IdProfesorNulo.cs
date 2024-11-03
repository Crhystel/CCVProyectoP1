using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class IdProfesorNulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase");

            migrationBuilder.AlterColumn<int>(
                name: "IdProfesor",
                table: "Clase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase",
                column: "IdProfesor",
                principalTable: "Profesor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Profesor_IdProfesor",
                table: "Clase");

            migrationBuilder.AlterColumn<int>(
                name: "IdProfesor",
                table: "Clase",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
