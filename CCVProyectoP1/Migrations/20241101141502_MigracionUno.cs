using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class MigracionUno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Cedula = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Contrasenia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    Cedula = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Materia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Contrasenia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Cedula);
                });

            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "Cedula", "Contrasenia", "Edad", "Nombre", "NombreUsuario", "Rol" },
                values: new object[] { 1234567890L, "admin", 30, "Roberto", "admin", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Profesor");
        }
    }
}
