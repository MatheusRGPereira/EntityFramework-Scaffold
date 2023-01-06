using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoGama.Migrations
{
    /// <inheritdoc />
    public partial class novaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "marca",
                table: "tb_carros");

            migrationBuilder.DropColumn(
                name: "modelo",
                table: "tb_carros");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "tb_marcas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "tb_carros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModeloId",
                table: "tb_carros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_carros_MarcaId",
                table: "tb_carros",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_carros_ModeloId",
                table: "tb_carros",
                column: "ModeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_carros_tb_marcas_MarcaId",
                table: "tb_carros",
                column: "MarcaId",
                principalTable: "tb_marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_carros_tb_modelos_ModeloId",
                table: "tb_carros",
                column: "ModeloId",
                principalTable: "tb_modelos",
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
                name: "FK_tb_carros_tb_modelos_ModeloId",
                table: "tb_carros");

            migrationBuilder.DropIndex(
                name: "IX_tb_carros_MarcaId",
                table: "tb_carros");

            migrationBuilder.DropIndex(
                name: "IX_tb_carros_ModeloId",
                table: "tb_carros");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "tb_carros");

            migrationBuilder.DropColumn(
                name: "ModeloId",
                table: "tb_carros");

            migrationBuilder.UpdateData(
                table: "tb_marcas",
                keyColumn: "nome",
                keyValue: null,
                column: "nome",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "tb_marcas",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "marca",
                table: "tb_carros",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "modelo",
                table: "tb_carros",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
