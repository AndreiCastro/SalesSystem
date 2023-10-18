using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SalesSystem.WebApi.Dtos;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        #region Construtor
        public VendaController(IVendaRepository repository, IProdutoRepository produtoRepository, IMapper mapper)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
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
                var vendasModel = await _repository.GetAllVendas();
                var vendasDto = _mapper.Map<List<VendaDto>>(vendasModel);
                if (vendasDto == null)
                    return Conflict("Vendas não encontrados");
                else
                    return Ok(vendasDto);
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
                var vendaModel = await _repository.GetVendaPorId(idVenda);
                var vendaDto = _mapper.Map<VendaDto>(vendaModel);
                if (vendaDto == null)
                    return Conflict("Venda não encontrada.");
                else
                    return Ok(vendaDto);
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
        public async Task<IActionResult> Post(VendaDto vendaDto)
        {
            try
            {
                var validaVenda = new VendaModel(_repository, _produtoRepository);
                var vendaModel = _mapper.Map<VendaModel>(vendaDto);
                (bool valido, string textoErro) = await validaVenda.ValidaInclusaoVenda(vendaModel);

                if (valido)
                    return Ok(vendaDto);
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
                var validaVenda = new VendaModel(_repository, _produtoRepository);
                (bool valido, string textoErro) = await validaVenda.ValidaExclusaoVenda(idVenda);

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
