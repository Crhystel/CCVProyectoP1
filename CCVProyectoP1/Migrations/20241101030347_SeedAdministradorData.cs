using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdministradorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Administrador",
            columns: new[] { "Usuario", "Contrasenia" },
            values: new object[] { "admin", "admin" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Administrador",
            keyColumn: "Usuario",
            keyValue: "admin");

        }
    }
}
