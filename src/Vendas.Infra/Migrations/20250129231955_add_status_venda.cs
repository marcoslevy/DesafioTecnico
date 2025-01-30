using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vendas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class add_status_venda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataFaturamento",
                table: "Vendas",
                newName: "DataStatus");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "DataStatus",
                table: "Vendas",
                newName: "DataFaturamento");
        }
    }
}
