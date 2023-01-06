using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoGama.Migrations
{
    /// <inheritdoc />
    public partial class RenomeandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dias_de_locacao",
                table: "tb_configuracoes",
                newName: "diasDeLocacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "diasDeLocacao",
                table: "tb_configuracoes",
                newName: "dias_de_locacao");
        }
    }
}
