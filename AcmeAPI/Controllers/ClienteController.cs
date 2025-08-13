using AcmeAPI.Interfaces;
using AcmeAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcmeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var resultado = await _clienteRepository.GetAllAsync();
            return Ok(resultado);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var resultado = await _clienteRepository.GetByIdAsync(id);
            return Ok(resultado);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
            return Ok();
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);
            return Ok();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clienteRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
