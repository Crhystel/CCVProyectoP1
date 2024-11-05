using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCVProyectoP1.Migrations
{
    /// <inheritdoc />
    public partial class MM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clase",
                table: "Profesor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clase",
                table: "Profesor");
        }
    }
}
