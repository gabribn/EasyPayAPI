using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProdutos.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigracaodd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Vendas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Vendas");
        }
    }
}
