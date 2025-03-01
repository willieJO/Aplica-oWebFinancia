using APIFinancia.Domain;

namespace APIFinancia.Infra.Repository
{
    public interface IUsuarioRepository
    {
        Task AddAsync(User usuario);
        Task UpdateAsync(User usuairo);
        Task DeleteAsync(User usuario);
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetAll();
    }
}
