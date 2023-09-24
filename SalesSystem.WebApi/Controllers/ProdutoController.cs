using Microsoft.AspNetCore.Mvc;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        #region Construtor
        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }
        #endregion Construtor

        #region Get
        /// <summary>
        /// Método para retornar todos os produtos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAllProdutos());
        }

        /// <summary>
        /// Método para retornar um produto
        /// </summary>
        /// <param name="idProduto"></param>
        [HttpGet("{idProduto:int}")]
        public async Task<IActionResult> Get(int idProduto)
        {
            var produto = await _repository.GetProduto(idProduto);
            if (produto == null)
                return BadRequest();

            return Ok(produto);
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Método para cadastrar um produto
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(ProdutoModel produto)
        {
            _repository.Add(produto);
            if (await _repository.SaveChanges())
                return Ok(produto);

            return BadRequest();
        }
        #endregion Post

        #region Put
        /// <summary>
        /// Método para alterar um produto
        /// </summary>
        /// <param name="idProduto"></param>
        [HttpPut("{idProduto:int}")]
        public async Task<IActionResult> Put(int idProduto, ProdutoModel produto)
        {
            var produtoDB = await _repository.GetProduto(idProduto);
            if (produtoDB != null)
            {
                _repository.Update(produto);
                if (await _repository.SaveChanges()) 
                    return Ok(produto);
            }
            return BadRequest();
        }
        #endregion Put

        #region Delete
        /// <summary>
        /// Método para excluir um produto
        /// </summary>
        /// <param name="idProduto"></param>
        [HttpDelete("{idProduto:int}")]
        public async Task<IActionResult> Delete(int idProduto)
        {
            var produto = await _repository.GetProduto(idProduto);
            if (produto != null)
            {
                _repository.Delete(produto);
                if (await _repository.SaveChanges())
                    return Ok();

            }
            return BadRequest();
        }
        #endregion Delete        
    }
}
