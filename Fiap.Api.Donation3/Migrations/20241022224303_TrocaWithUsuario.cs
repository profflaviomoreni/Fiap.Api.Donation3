using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Donation3.Migrations
{
    /// <inheritdoc />
    public partial class TrocaWithUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Troca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Troca_UsuarioId",
                table: "Troca",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Troca_Usuario_UsuarioId",
                table: "Troca",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Troca_Usuario_UsuarioId",
                table: "Troca");

            migrationBuilder.DropIndex(
                name: "IX_Troca_UsuarioId",
                table: "Troca");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Troca");
        }
    }
}
