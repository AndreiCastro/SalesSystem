using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesSystem.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    CpfCnpj = table.Column<string>(maxLength: 14, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 30, nullable: false),
                    Bairro = table.Column<string>(maxLength: 20, nullable: false),
                    Uf = table.Column<string>(maxLength: 2, nullable: false),
                    Cep = table.Column<string>(maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(maxLength: 20, nullable: false),
                    Telefone = table.Column<string>(maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    UnidadeMedida = table.Column<string>(maxLength: 3, nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    DataValidade = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    QuantidadeProduto = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: true),
                    Desconto = table.Column<decimal>(nullable: true),
                    IdCliente = table.Column<int>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdCliente",
                table: "Vendas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdProduto",
                table: "Vendas",
                column: "IdProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
