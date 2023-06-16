using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Repositories.Interfaces;
using CashFlow.Service.Interface;

namespace CashFlow.Service;

public class BalanceService : IBalanceService
{
    private readonly ITransactionRepository _transactionRepository;

    public BalanceService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }


    public async Task<Balance> GetBalanceAsync()
    {
        var transactions = await _transactionRepository.GetAllAsync();
        var balance = new Balance() 
            { 
                Value = transactions.Sum(t => t.Amount) 
            };

        return balance;
    }
}
