using SalesSystem.WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Repository
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> GetAllClientes();

        Task<ClienteModel> GetCliente(int idCliente);

        void Add(ClienteModel cliente);

        void Delete(ClienteModel cliente);

        void Update(ClienteModel cliente);

        Task<bool> SaveChanges();
    }
}
