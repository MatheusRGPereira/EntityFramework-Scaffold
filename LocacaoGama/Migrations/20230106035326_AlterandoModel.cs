using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoGama.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedidos_tb_carros_CarroId",
                table: "tb_pedidos");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedidos_CarroId",
                table: "tb_pedidos");

            migrationBuilder.RenameColumn(
                name: "dias_de_locacao",
                table: "tb_configuracoes",
                newName: "diasDeLocacao");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "tb_modelos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "diasDeLocacao",
                table: "tb_configuracoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.CreateIndex(
                name: "IX_tb_modelos_MarcaId",
                table: "tb_modelos",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_modelos_tb_marcas_MarcaId",
                table: "tb_modelos",
                column: "MarcaId",
                principalTable: "tb_marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_modelos_tb_marcas_MarcaId",
                table: "tb_modelos");

            migrationBuilder.DropIndex(
                name: "IX_tb_modelos_MarcaId",
                table: "tb_modelos");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "tb_modelos");

            migrationBuilder.RenameColumn(
                name: "diasDeLocacao",
                table: "tb_configuracoes",
                newName: "dias_de_locacao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dias_de_locacao",
                table: "tb_configuracoes",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_CarroId",
                table: "tb_pedidos",
                column: "CarroId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedidos_tb_carros_CarroId",
                table: "tb_pedidos",
                column: "CarroId",
                principalTable: "tb_carros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
