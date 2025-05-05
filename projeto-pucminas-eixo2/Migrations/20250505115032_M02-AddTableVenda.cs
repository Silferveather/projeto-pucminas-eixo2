using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeto_pucminas_eixo2.Migrations
{
    /// <inheritdoc />
    public partial class M02AddTableVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Km",
                table: "Vendas",
                newName: "QuantidadeVenda");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Vendas",
                newName: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "Produtos",
                newName: "Marca");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorProduto",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantidadeVenda",
                table: "Vendas",
                newName: "Km");

            migrationBuilder.RenameColumn(
                name: "Cliente",
                table: "Vendas",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Produtos",
                newName: "Placa");

            migrationBuilder.AlterColumn<int>(
                name: "ValorProduto",
                table: "Produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
