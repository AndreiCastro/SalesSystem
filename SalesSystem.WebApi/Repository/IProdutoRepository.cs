using SalesSystem.WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Repository
{
    public interface IProdutoRepository
    {
        Task<List<ProdutoModel>> GetAllProdutos();

        Task<ProdutoModel> GetProdutoPorId(int idProduto);

        void Add(ProdutoModel produto);

        void Delete(ProdutoModel produto);

        void Update(ProdutoModel produto);

        Task<bool> SaveChanges();
    }
}
