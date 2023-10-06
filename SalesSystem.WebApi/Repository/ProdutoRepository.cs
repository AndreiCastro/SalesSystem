using Microsoft.EntityFrameworkCore;
using SalesSystem.WebApi.Data;
using SalesSystem.WebApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Context _context;

        public ProdutoRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ProdutoModel>> GetAllProdutos()
        {
            return await _context.Produtos.AsNoTrackingWithIdentityResolution().OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<ProdutoModel> GetProdutoPorId(int id)
        {
            return await _context.Produtos.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(x => x.Id == id);
        }


        public void Add(ProdutoModel produto)
        {
            _context.AddAsync(produto);
        }

        public void Delete(ProdutoModel produto)
        {
            _context.Remove(produto);
        }

        public void Update(ProdutoModel produto)
        {
            _context.Update(produto);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
