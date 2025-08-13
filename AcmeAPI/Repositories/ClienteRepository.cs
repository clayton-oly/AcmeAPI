using AcmeAPI.Data;
using AcmeAPI.Interfaces;
using AcmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcmeAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AcmeDbContext _context;

        public ClienteRepository(AcmeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            //listar todos registros
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            //selecione os registro por id
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            //insere (salva) o registro no banco de dados
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            //atualiza o registro no banco de dados
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            //apaga o registro da tabela
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }



    }
}
