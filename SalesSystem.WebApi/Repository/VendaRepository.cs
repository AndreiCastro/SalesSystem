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
            return await _context.Vendas.AsNoTrackingWithIdentityResolution()
                .Include(c => c.Cliente)
                .Include(p => p.Produto)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<VendaModel> GetVendaPorId(int id)
        {
            return await _context.Vendas.AsNoTrackingWithIdentityResolution()
                .Include(c => c.Cliente)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public void Add(VendaModel venda)
        {
            _context.AddAsync(venda);
        }

        public void ChangeTrackerClear()
        {
            //Esse metodo serve somente para não dar erro: ChangeTracking.Internal.IdentityMap
            _context.ChangeTracker.Clear();
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
