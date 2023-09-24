using Microsoft.EntityFrameworkCore;
using SalesSystem.WebApi.Model;

namespace SalesSystem.WebApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<VendaModel> Vendas { get; set; }
    }
}
