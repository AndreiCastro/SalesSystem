using Microsoft.AspNetCore.Mvc;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")] 
    //Deixa o /[action] pra usar de exemplo, pois pode-se colocar a ação da requisição. Já nas outras Controllers não tem o action
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        #region Construtor
        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
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
                var clientes = await _repository.GetAllClientes();
                if (clientes == null)
                    return NotFound("Clientes não encontrados");
                else
                    return Ok(clientes);
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
                var cliente = await _repository.GetCliente(idCliente);
                if (cliente == null)
                    return NotFound("Cliente não encontrado");
                else
                    return Ok(cliente);                
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
        public async Task<IActionResult> Post(ClienteModel cliente)
        {
            try
            {
                _repository.Add(cliente);
                if (await _repository.SaveChanges())
                    return Ok(cliente);
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
        public async Task<IActionResult> Put(int idCliente, ClienteModel cliente)
        {
            try
            {
                var clienteDB = await _repository.GetCliente(idCliente);
                if (clienteDB != null)
                {
                    _repository.Update(cliente);
                    if (await _repository.SaveChanges())
                        return Ok(cliente);
                    else
                        return Conflict("Cliente não foi alterado, erro ao alterar no banco de dados.");
                }
                else
                {
                    return NotFound("Cliente não encontrado.");
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
                var cliente = await _repository.GetCliente(idCliente);
                if (cliente != null)
                {
                    _repository.Delete(cliente);
                    if (await _repository.SaveChanges())
                        return Ok();
                    else
                        return Conflict("Cliente não foi deletado, erro ao deletar no banco de dados.");
                }
                else
                {
                    return NotFound("Cliente não encontrado.");
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
