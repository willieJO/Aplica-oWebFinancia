using APIFinancia.Domain;
using APIFinancia.Infra;
using Microsoft.EntityFrameworkCore;

namespace APIFinancia.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return  await _context.Usuarios.ToListAsync();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            return _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(User usuairo)
        {
            var existeUsuario = await _context.Usuarios.FindAsync(usuairo.Id);
            if (existeUsuario == null)
            {
                throw new KeyNotFoundException("Usuario não encontrado");
            }
            existeUsuario.Name = usuairo.Name;
            existeUsuario.Email = usuairo.Email;
            existeUsuario.Senha = usuairo.Senha;
            await _context.SaveChangesAsync();
        }
    }
}
