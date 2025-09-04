using AcmeAPI.DTOs;
using AcmeAPI.Interfaces;
using AcmeAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcmeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var clientes = await _clienteRepository.GetAllAsync();

            var resultado = new List<ClienteOutputDTO>();

            foreach (var cliente in clientes)
            {
                resultado.Add(new ClienteOutputDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    DataNascimento = cliente.DataNascimento,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone,
                    IdTipo = cliente.TipoId,
                    Tipo = cliente.Tipo.Nome

                });
            }

            return Ok(resultado);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            //convertendo minha model dto em classe dto
            var resultado = new ClienteOutputDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                IdTipo = cliente.TipoId,
                Tipo = cliente.Tipo.Nome
            };

            return Ok(resultado);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteInputDTO dto)
        {
            //convertendo minha classe dto em classe model
            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento,
                Email = dto.Email,
                Telefone = dto.Telefone,
                TipoId = dto.IdTipo
            };

            await _clienteRepository.AddAsync(cliente);
            return Ok();
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteInputDTO dto)
        {
            //convertendo minha classe dto em classe model
            var cliente = new Cliente
            {
                Id = id,
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento,
                Email = dto.Email,
                Telefone = dto.Telefone,
                TipoId = dto.IdTipo,
            };

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
