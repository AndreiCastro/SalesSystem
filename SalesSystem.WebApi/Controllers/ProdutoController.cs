using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        #region Construtor
        public ProdutoController(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
                var produtosModel = await _repository.GetAllProdutos();
                var produtosDto = _mapper.Map<List<ProdutoDto>>(produtosModel);
                if (produtosDto == null)
                    return Conflict("Produtos não encontrados");
                else
                    return Ok(produtosDto);
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
                var produtoModel = await _repository.GetProdutoPorId(idProduto);
                var produtoDto = _mapper.Map<ProdutoDto>(produtoModel);
                if (produtoDto == null)
                    return Conflict("Produto não encontrado");
                else
                    return Ok(produtoDto);
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
        public async Task<IActionResult> Post(ProdutoDto produtoDto)
        {
            try
            {
                var produtoModel = _mapper.Map<ProdutoModel>(produtoDto);
                _repository.Add(produtoModel);
                if (await _repository.SaveChanges())
                    return Ok(produtoDto);
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
        public async Task<IActionResult> Put(int idProduto, ProdutoDto produtoDto)
        {
            try
            {
                var produtoDB = await _repository.GetProdutoPorId(idProduto);
                if (produtoDB != null)
                {
                    var produtoModel = _mapper.Map<ProdutoModel>(produtoDto);
                    _repository.Update(produtoModel);
                    if (await _repository.SaveChanges())
                        return Ok(produtoDto);
                    else
                        return Conflict("Poduto não foi alterado, erro ao alterar no banco de dados.");
                }
                else
                {
                    return Conflict("Produto não encontrado.");
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
                var produtoModel = await _repository.GetProdutoPorId(idProduto);
                if (produtoModel != null)
                {
                    _repository.Delete(produtoModel);
                    if (await _repository.SaveChanges())
                        return Ok();
                    else
                        return Conflict("Produto não foi deletado, erro ao deletar no banco de dados.");
                }
                else
                {
                    return Conflict("Produto não encontrado.");
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
