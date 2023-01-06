using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoGama.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_carros_tb_marcas_MarcaId",
                table: "tb_carros");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedidos_tb_clientes_ClienteId",
                table: "tb_pedidos");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedidos_ClienteId",
                table: "tb_pedidos");

            migrationBuilder.DropColumn(
                name: "Carro",
                table: "tb_pedidos");

            migrationBuilder.RenameColumn(
                name: "diasDeLocacao",
                table: "tb_configuracoes",
                newName: "dias_de_locacao");

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

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "tb_carros",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "tb_carros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_CarroId",
                table: "tb_pedidos",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_ClienteId1",
                table: "tb_pedidos",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_carros_tb_marcas_MarcaId",
                table: "tb_carros",
                column: "MarcaId",
                principalTable: "tb_marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedidos_tb_carros_CarroId",
                table: "tb_pedidos",
                column: "CarroId",
                principalTable: "tb_carros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedidos_tb_clientes_ClienteId1",
                table: "tb_pedidos",
                column: "ClienteId1",
                principalTable: "tb_clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_carros_tb_marcas_MarcaId",
                table: "tb_carros");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedidos_tb_carros_CarroId",
                table: "tb_pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedidos_tb_clientes_ClienteId1",
                table: "tb_pedidos");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedidos_CarroId",
                table: "tb_pedidos");

            migrationBuilder.DropIndex(
                name: "IX_tb_pedidos_ClienteId1",
                table: "tb_pedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "tb_pedidos");

            migrationBuilder.RenameColumn(
                name: "dias_de_locacao",
                table: "tb_configuracoes",
                newName: "diasDeLocacao");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "tb_pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Carro",
                table: "tb_pedidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "tb_carros",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "tb_carros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_ClienteId",
                table: "tb_pedidos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_carros_tb_marcas_MarcaId",
                table: "tb_carros",
                column: "MarcaId",
                principalTable: "tb_marcas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedidos_tb_clientes_ClienteId",
                table: "tb_pedidos",
                column: "ClienteId",
                principalTable: "tb_clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
