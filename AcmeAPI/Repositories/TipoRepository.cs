using AcmeAPI.Data;
using AcmeAPI.Interfaces;
using AcmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcmeAPI.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        private readonly AcmeDbContext _context;

        public TipoRepository(AcmeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tipo>> GetAllAsync()
        {
            //listar todos registros
            return await _context.Tipos.ToListAsync();
        }

        public async Task<Tipo?> GetByIdAsync(int id)
        {
            //selecione os registro por id
            return await _context.Tipos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Tipo tipo)
        {
            //insere (salva) o registro no banco de dados
            await _context.Tipos.AddAsync(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tipo tipo)
        {
            //atualiza o registro no banco de dados
            _context.Tipos.Update(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            //apaga o registro da tabela
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo != null)
            {
                _context.Tipos.Remove(tipo);
                await _context.SaveChangesAsync();
            }
        }

    }
}
