
namespace APIFinancia.Repository.Expense
{
    public interface IExpenseRepository
    {
        Task AddAsync(Domain.Expense usuario);
        Task UpdateAsync(Domain.Expense usuairo);
        Task DeleteAsync(Domain.Expense usuario);
        Task<Domain.Expense> GetByIdAsync(Guid id);
        Task<List<Domain.Expense>> GetAll();
    }
}
