using Microsoft.EntityFrameworkCore;
using SalesSystem.WebApi.Data;
using SalesSystem.WebApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly Context _context;

        public VendaRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<VendaModel>> GetAllVendas()
        {
            return await _context.Vendas.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<VendaModel> GetVenda(int id)
        {
            return await _context.Vendas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }


        public void Add(VendaModel venda)
        {
            _context.Add(venda);
        }

        public void Delete(VendaModel venda)
        {
            _context.Remove(venda);
        }

        public void Update(VendaModel venda)
        {
            _context.Update(venda);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
