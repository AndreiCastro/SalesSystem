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
    [Route("api/[controller]/[action]")] 
    //Deixa o /[action] pra usar de exemplo, pois pode-se colocar a ação da requisição. Já nas outras Controllers não tem o action
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        #region Construtor
        public ClienteController(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion Construtor

        #region Get
        /// <summary>
        /// Método para retornar todos os clientes
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientesModel = await _repository.GetAllClientes();
                var clientesDto = _mapper.Map<List<ClienteDto>>(clientesModel);
                if (clientesDto == null)
                    return Conflict("Clientes não encontrados");
                else
                    return Ok(clientesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Método para retornar um cliente
        /// </summary>
        /// <param name="idCliente"></param>
        [HttpGet("{idCliente:int}")]
        public async Task<IActionResult> Get(int idCliente)
        {
            try
            {
                var clienteModel = await _repository.GetClientePorId(idCliente);
                var clienteDto = _mapper.Map<ClienteDto>(clienteModel);
                if (clienteDto == null)
                    return Conflict("Cliente não encontrado");
                else
                    return Ok(clienteDto);                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Método para cadastrar um cliente
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(ClienteDto clienteDto)
        {
            try
            {
                var clienteModel = _mapper.Map<ClienteModel>(clienteDto);
                _repository.Add(clienteModel);
                if (await _repository.SaveChanges())
                    return Ok(clienteDto);
                else
                    return Conflict("Cliente não cadastrado, erro ao inserir no banco de dados.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }
        #endregion Post

        #region Put
        /// <summary>
        /// Método para alterar um cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="cliente"></param>
        [HttpPut("{idCliente:int}")]
        public async Task<IActionResult> Put(int idCliente, ClienteDto clienteDto)
        {
            try
            {
                var clienteDB = await _repository.GetClientePorId(idCliente);
                if (clienteDB != null)
                {
                    var clienteModel = _mapper.Map<ClienteModel>(clienteDto);
                    _repository.Update(clienteModel);
                    if (await _repository.SaveChanges())
                        return Ok(clienteDto);
                    else
                        return Conflict("Cliente não foi alterado, erro ao alterar no banco de dados.");
                }
                else
                {
                    return Conflict("Cliente não encontrado.");
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
        /// Método para excluir um cliente
        /// </summary>
        /// <param name="idCliente"></param>
        [HttpDelete("{idCliente:int}")]
        public async Task<IActionResult> Delete(int idCliente)
        {
            try
            {
                var clienteModel = await _repository.GetClientePorId(idCliente);
                if (clienteModel != null)
                {
                    _repository.Delete(clienteModel);
                    if (await _repository.SaveChanges())
                        return Ok();
                    else
                        return Conflict("Cliente não foi deletado, erro ao deletar no banco de dados.");
                }
                else
                {
                    return Conflict("Cliente não encontrado.");
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
