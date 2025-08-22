using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcmeAPI.Migrations
{
    /// <inheritdoc />
    public partial class TipoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipo",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoId",
                table: "Clientes",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Tipos_TipoId",
                table: "Clientes",
                column: "TipoId",
                principalTable: "Tipos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Tipos_TipoId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_TipoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdTipo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Clientes");
        }
    }
}
