using Microsoft.AspNetCore.Mvc;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _repository;

        #region Construtor
        public VendaController(IVendaRepository repository)
        {
            _repository = repository;
        }
        #endregion Construtor

        #region Get
        /// <summary>
        /// Método para retornar todas as vendas
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAllVendas());
        }

        /// <summary>
        /// Método para retornar uma venda
        /// </summary>
        /// <param name="idVenda"></param>
        [HttpGet("{idVenda:int}")]
        public async Task<IActionResult> Get(int idVenda)
        {
            var venda = await _repository.GetVenda(idVenda);
            if (venda == null)
                return BadRequest();

            return Ok(venda);
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Método para cadastrar uma venda
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(VendaModel venda)
        {
            _repository.Add(venda);
            if (await _repository.SaveChanges())
                return Ok(venda);

            return BadRequest();
        }
        #endregion Post

        #region Put
        /// <summary>
        /// Método para alterar uma venda
        /// </summary>
        /// <param name="idVenda"></param>
        [HttpPut("{idVenda:int}")]
        public async Task<IActionResult> Put(int idVenda, VendaModel venda)
        {
            var vendaDB = await _repository.GetVenda(idVenda);
            if (vendaDB != null)
            {
                _repository.Update(venda);
                if (await _repository.SaveChanges()) 
                    return Ok(venda);
            }
            return BadRequest();
        }
        #endregion Put

        #region Delete
        /// <summary>
        /// Método para excluir uma venda
        /// </summary>
        /// <param name="idVenda"></param>
        [HttpDelete("{idVenda:int}")]
        public async Task<IActionResult> Delete(int idVenda)
        {
            var venda = await _repository.GetVenda(idVenda);
            if (venda != null)
            {
                _repository.Delete(venda);
                if (await _repository.SaveChanges())
                    return Ok();

            }
            return BadRequest();
        }
        #endregion Delete        
    }
}
