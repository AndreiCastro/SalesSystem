using Microsoft.AspNetCore.Mvc;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System;
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
            try
            {
                var produtos = await _repository.GetAllProdutos();
                if (produtos == null)
                    return NotFound("Produtos não encontrados");
                else
                    return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para retornar um produto
        /// </summary>
        /// <param name="idProduto"></param>
        [HttpGet("{idProduto:int}")]
        public async Task<IActionResult> Get(int idProduto)
        {
            try
            {
                var produto = await _repository.GetProduto(idProduto);
                if (produto == null)
                    return NotFound("Produto não encontrado");
                else
                    return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Método para cadastrar um produto
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(ProdutoModel produto)
        {
            try
            {
                _repository.Add(produto);
                if (await _repository.SaveChanges())
                    return Ok(produto);
                else
                    return Conflict("Produto não cadastrado, erro ao inserir no banco de dados.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
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
            try
            {
                var produtoDB = await _repository.GetProduto(idProduto);
                if (produtoDB != null)
                {
                    _repository.Update(produto);
                    if (await _repository.SaveChanges())
                        return Ok(produto);
                    else
                        return Conflict("Poduto não foi alterado, erro ao alterar no banco de dados.");
                }
                else
                {
                    return NotFound("Produto não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
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
            try
            {
                var produto = await _repository.GetProduto(idProduto);
                if (produto != null)
                {
                    _repository.Delete(produto);
                    if (await _repository.SaveChanges())
                        return Ok();
                    else
                        return Conflict("Produto não foi deletado, erro ao deletar no banco de dados.");
                }
                else
                {
                    return NotFound("Produto não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion Delete        
    }
}
