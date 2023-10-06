using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                    return Conflict("Vendas não encontrados");
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
                var venda = await _repository.GetVendaPorId(idVenda);
                if (venda == null)
                    return Conflict("Venda não encontrada.");
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
                var vendaModel = new VendaModel(_repository, _produtoRepository);
                (bool valido, string textoErro) = await vendaModel.ValidaInclusaoVenda(venda);

                if (valido)
                    return Ok(venda);
                else
                    return Conflict(textoErro);
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
                var vendaModel = new VendaModel(_repository, _produtoRepository);
                (bool valido, string textoErro) = await vendaModel.ValidaExclusaoVenda(idVenda);

                if (valido)
                        return Ok();
                    else
                        return Conflict(textoErro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion Delete        
    }
}
