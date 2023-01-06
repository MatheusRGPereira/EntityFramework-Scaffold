using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoGama.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoClienteId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedidos_tb_clientes_ClienteId1",
                table: "tb_pedidos");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedidos_ClienteId1",
                table: "tb_pedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "tb_pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "tb_pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_ClienteId",
                table: "tb_pedidos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedidos_tb_clientes_ClienteId",
                table: "tb_pedidos",
                column: "ClienteId",
                principalTable: "tb_clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedidos_tb_clientes_ClienteId",
                table: "tb_pedidos");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedidos_ClienteId",
                table: "tb_pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteId",
                table: "tb_pedidos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId1",
                table: "tb_pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_ClienteId1",
                table: "tb_pedidos",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedidos_tb_clientes_ClienteId1",
                table: "tb_pedidos",
                column: "ClienteId1",
                principalTable: "tb_clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
