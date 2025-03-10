
using APIFinancia.Infra;

namespace APIFinancia.Repository.Expense
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Expense usuario)
        {
            await _context.Expense.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Domain.Expense usuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Expense>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Expense> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Expense usuairo)
        {
            throw new NotImplementedException();
        }
    }
}
