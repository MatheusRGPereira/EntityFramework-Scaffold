using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoGama.Migrations
{
    /// <inheritdoc />
    public partial class ClienteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modelo",
                table: "tb_clientes",
                newName: "telefone");

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "tb_clientes",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endereco",
                table: "tb_clientes");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "tb_clientes",
                newName: "modelo");
        }
    }
}
