using Microsoft.AspNetCore.Mvc;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
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
            return Ok(await _repository.GetAllClientes());
        }

        /// <summary>
        /// Método para retornar um cliente
        /// </summary>
        /// <param name="idCliente"></param>
        [HttpGet("{idCliente:int}")]
        public async Task<IActionResult> Get(int idCliente)
        {
            var cliente = await _repository.GetCliente(idCliente);
            if (cliente == null)
                return BadRequest();

            return Ok(cliente);
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Método para cadastrar um cliente
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(ClienteModel cliente)
        {
            _repository.Add(cliente);
            if (await _repository.SaveChanges())
                return Ok(cliente);

            return BadRequest();
        }
        #endregion Post

        #region Put
        /// <summary>
        /// Método para alterar um cliente
        /// </summary>
        /// <param name="idCliente"></param>
        [HttpPut("{idCliente:int}")]
        public async Task<IActionResult> Put(int idCliente, ClienteModel cliente)
        {
            var clienteDB = await _repository.GetCliente(idCliente);
            if (clienteDB != null)
            {
                _repository.Update(cliente);
                if (await _repository.SaveChanges()) 
                    return Ok(cliente);
            }
            return BadRequest();
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
            var cliente = await _repository.GetCliente(idCliente);
            if (cliente != null)
            {
                _repository.Delete(cliente);
                if (await _repository.SaveChanges())
                    return Ok();

            }
            return BadRequest();
        }
        #endregion Delete        
    }
}
