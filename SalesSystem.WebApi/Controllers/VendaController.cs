using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _repository;
        private readonly IProdutoRepository _produtoRepository;

        #region Construtor
        public VendaController(IVendaRepository repository, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
        }
        #endregion Construtor

        #region Get
        /// <summary>
        /// Método para retornar todas as vendas
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vendas = await _repository.GetAllVendas();
                if (vendas == null)
                    return NotFound("Vendas não encontrados");
                else
                    return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para retornar uma venda
        /// </summary>
        /// <param name="idVenda"></param>
        [HttpGet("{idVenda:int}")]
        public async Task<IActionResult> Get(int idVenda)
        {
            try
            {
                var venda = await _repository.GetVenda(idVenda);
                if (venda == null)
                    return BadRequest();
                else
                    return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Método para cadastrar uma venda
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(VendaModel venda)
        {
            try
            {
                var produto = await _produtoRepository.GetProduto(venda.IdProduto);
                if (produto.DataValidade < DateTime.Now)
                    return BadRequest("Produto fora da data de validade.");

                if ((produto.Quantidade - venda.QuantidadeProduto) < 0)
                    return BadRequest("Estoque do produto insuficiente.");

                venda.DataVenda = DateTime.Now;
                venda.ValorTotal = venda.Desconto == null ? produto.Preco * venda.QuantidadeProduto 
                    : (produto.Preco * venda.QuantidadeProduto) - Convert.ToDecimal(venda.Desconto);

                _repository.Add(venda);
                if (await _repository.SaveChanges())
                {
                    produto.Quantidade -= venda.QuantidadeProduto;
                    _produtoRepository.Update(produto);

                    if (await _repository.SaveChanges())
                        return Ok(venda);
                    else
                        return BadRequest("Erro ao alterar quantidade do produto vendido.");
                }
                else
                {
                    return NotFound("Venda não cadastrada, erro ao inserir no banco de dados.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion Post
        
        #region Delete
        /// <summary>
        /// Método para excluir uma venda
        /// </summary>
        /// <param name="idVenda"></param>
        [HttpDelete("{idVenda:int}")]
        public async Task<IActionResult> Delete(int idVenda)
        {
            try
            {
                var venda = await _repository.GetVenda(idVenda);
                if (venda != null)
                {                    
                    _repository.Delete(venda);
                    if (await _repository.SaveChanges())                    
                        return Ok();
                    else
                        return BadRequest("Erro ao alterar o produto.");                 
                }
                else
                {
                    return NotFound("Venda não encontrada.");
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
