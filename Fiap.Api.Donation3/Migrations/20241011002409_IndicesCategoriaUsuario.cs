using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Donation3.Migrations
{
    /// <inheritdoc />
    public partial class IndicesCategoriaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuario_NomeUsuario",
                table: "Usuario",
                column: "NomeUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_NomeCategoria",
                table: "Categoria",
                column: "NomeCategoria",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_NomeUsuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_NomeCategoria",
                table: "Categoria");
        }
    }
}
