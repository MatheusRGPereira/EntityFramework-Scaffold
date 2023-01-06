using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoGama.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoRelacionamentoConfiguracaoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfiguracaoId",
                table: "tb_pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_ConfiguracaoId",
                table: "tb_pedidos",
                column: "ConfiguracaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedidos_tb_configuracoes_ConfiguracaoId",
                table: "tb_pedidos",
                column: "ConfiguracaoId",
                principalTable: "tb_configuracoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedidos_tb_configuracoes_ConfiguracaoId",
                table: "tb_pedidos");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedidos_ConfiguracaoId",
                table: "tb_pedidos");

            migrationBuilder.DropColumn(
                name: "ConfiguracaoId",
                table: "tb_pedidos");
        }
    }
}
