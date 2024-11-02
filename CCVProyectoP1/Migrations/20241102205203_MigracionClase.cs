using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class MigracionClase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClaseId",
                table: "Estudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfesor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clase_Profesor_IdProfesor",
                        column: x => x.IdProfesor,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_ClaseId",
                table: "Estudiante",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_IdProfesor",
                table: "Clase",
                column: "IdProfesor");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Clase_ClaseId",
                table: "Estudiante",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Clase_ClaseId",
                table: "Estudiante");

            migrationBuilder.DropTable(
                name: "Clase");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_ClaseId",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "ClaseId",
                table: "Estudiante");
        }
    }
}
