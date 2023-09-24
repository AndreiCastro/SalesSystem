using SalesSystem.WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Repository
{
    public interface IVendaRepository
    {
        Task<List<VendaModel>> GetAllVendas();

        Task<VendaModel> GetVenda(int idVenda);

        void Add(VendaModel venda);

        void Delete(VendaModel venda);

        void Update(VendaModel venda);

        Task<bool> SaveChanges();
    }
}
