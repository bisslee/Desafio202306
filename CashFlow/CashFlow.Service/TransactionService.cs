
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Repositories.Interfaces;
using CashFlow.Service.Interface;

namespace CashFlow.Service;

public class TransactionService: ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task AddAsync(Transaction entity)
    {
       await _transactionRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(Transaction entity)
    {
        await _transactionRepository.DeleteAsync(entity);
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
       return await _transactionRepository.GetAllAsync();
    }

    public async Task<Transaction> GetByIdAsync(Guid id)
    {
        return await _transactionRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Transaction entity)
    {
        await _transactionRepository.UpdateAsync(entity);
    }
}
