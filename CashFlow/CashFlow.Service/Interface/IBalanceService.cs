using CashFlow.Domain.Models;

namespace CashFlow.Service.Interface;

public interface IBalanceService
{
    Task<Balance> GetBalanceAsync();
}
