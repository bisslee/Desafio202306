using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Data.Contexts;
using CashFlow.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CashFlowDbContext _dbContext;

        public TransactionRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Transaction entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.Now;
            await _dbContext.Transactions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbContext.Transactions.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Transaction entity)
        {
            _dbContext.Transactions.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _dbContext.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _dbContext.Transactions.ToListAsync();
        }
    }
}
