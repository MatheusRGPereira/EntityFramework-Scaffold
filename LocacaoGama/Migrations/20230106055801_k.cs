using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoGama.Migrations
{
    /// <inheritdoc />
    public partial class k : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "data_locacao",
                table: "tb_pedidos",
                newName: "DataLocacao");

            migrationBuilder.RenameColumn(
                name: "data_entrega",
                table: "tb_pedidos",
                newName: "DataEntrega");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataLocacao",
                table: "tb_pedidos",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrega",
                table: "tb_pedidos",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataLocacao",
                table: "tb_pedidos",
                newName: "data_locacao");

            migrationBuilder.RenameColumn(
                name: "DataEntrega",
                table: "tb_pedidos",
                newName: "data_entrega");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_locacao",
                table: "tb_pedidos",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_entrega",
                table: "tb_pedidos",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
