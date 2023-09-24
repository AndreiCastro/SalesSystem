using Microsoft.EntityFrameworkCore;
using SalesSystem.WebApi.Data;
using SalesSystem.WebApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Context _context;

        public ClienteRepository(Context context)
        {
            _context = context;
        }
        
        public async Task<List<ClienteModel>> GetAllClientes()
        {
            return await _context.Clientes.AsNoTracking().OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<ClienteModel> GetCliente(int id)
        {
            return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }


        public void Add(ClienteModel cliente)
        {
            _context.Add(cliente);
        }

        public void Delete(ClienteModel cliente)
        {
            _context.Remove(cliente);
        }

        public void Update(ClienteModel cliente)
        {
            _context.Update(cliente);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
