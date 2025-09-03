using AcmeAPI.Data;
using AcmeAPI.Interfaces;
using AcmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcmeAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AcmeDbContext _context;

        public UsuarioRepository(AcmeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Usuario usuario)
        {
            //insere (salva) o registro no banco de dados
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            //atualiza o registro no banco de dados
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            //listar todos registros
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            //selecione os registro por id
            return await _context.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Usuario> GetByLoginAsync(string email, string senha)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public async Task DeleteAsync(int id)
        {
            //apaga o registro da tabela
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

    }
}