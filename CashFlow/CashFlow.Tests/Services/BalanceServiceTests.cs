using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Repositories.Interfaces;
using CashFlow.Service;
using CashFlow.Service.Interface;
using Moq;

namespace CashFlow.Tests.Services
{
    public class BalanceServiceTests
    {
        private readonly IBalanceService _balanceService;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;

        public BalanceServiceTests()
        {
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _balanceService = new BalanceService(_transactionRepositoryMock.Object);
        }

        [Fact]
        public async Task GetBalanceAsync_ShouldReturnBalanceBasedOnTransactions()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                new Transaction { Id = Guid.NewGuid(), Amount = 100 },
                new Transaction { Id = Guid.NewGuid(), Amount = 200 }
            };

            _transactionRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(transactions);

            var expectedBalance = transactions.Sum(t => t.Amount);

            // Act
            var result = await _balanceService.GetBalanceAsync();

            // Assert
            Assert.Equal(expectedBalance, result.Value);
        }

    }
}
