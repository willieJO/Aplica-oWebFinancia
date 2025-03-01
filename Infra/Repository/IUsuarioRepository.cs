using APIFinancia.Domain;

namespace APIFinancia.Infra.Repository
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuairo);
        Task DeleteAsync(Usuario usuario);
        Task<Usuario> GetByIdAsync(Guid id);
        Task<List<Usuario>> GetAll();
    }
}
