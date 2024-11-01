using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class MigracionCinco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Usuario);
                });

            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "Usuario", "Contrasenia" },
                values: new object[] { "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");
        }
    }
}
