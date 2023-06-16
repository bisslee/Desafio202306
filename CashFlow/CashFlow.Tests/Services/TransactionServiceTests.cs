using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Repositories.Interfaces;
using CashFlow.Service;
using CashFlow.Service.Interface;
using Moq;

namespace CashFlow.Tests.Services
{
    public class TransactionServiceTests
    {
        private readonly ITransactionService _transactionService;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;

        public TransactionServiceTests()
        {
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _transactionService = new TransactionService(_transactionRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllTransactions()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                new Transaction { Id = Guid.NewGuid(), Description = "Transaction 1", Amount = 100 },
                new Transaction { Id = Guid.NewGuid(), Description = "Transaction 2", Amount = 200 }
            };

            _transactionRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(transactions);

            // Act
            var result = await _transactionService.GetAllAsync();

            // Assert
            Assert.Equal(transactions.Count, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTransactionWithMatchingId()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            var transaction = new Transaction { Id = transactionId, Description = "Transaction 1", Amount = 100 };

            _transactionRepositoryMock.Setup(repo => repo.GetByIdAsync(transactionId)).ReturnsAsync(transaction);

            // Act
            var result = await _transactionService.GetByIdAsync(transactionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(transactionId, result.Id);
        }

        [Fact]
        public async Task AddAsync_ShouldAddNewTransaction()
        {
            // Arrange
            var newTransaction = new Transaction { Description = "New Transaction", Amount = 150 };

            // Act
            await _transactionService.AddAsync(newTransaction);

            // Assert
            _transactionRepositoryMock.Verify(repo => repo.AddAsync(newTransaction), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateExistingTransaction()
        {
            // Arrange
            var existingTransaction = new Transaction { Id = Guid.NewGuid(), Description = "Existing Transaction", Amount = 200 };

            // Act
            await _transactionService.UpdateAsync(existingTransaction);

            // Assert
            _transactionRepositoryMock.Verify(repo => repo.UpdateAsync(existingTransaction), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteExistingTransaction()
        {
            // Arrange
            var existingTransaction = new Transaction { Id = Guid.NewGuid(), Description = "Existing Transaction", Amount = 200 };

            // Act
            await _transactionService.DeleteAsync(existingTransaction);

            // Assert
            _transactionRepositoryMock.Verify(repo => repo.DeleteAsync(existingTransaction), Times.Once);
        }

    }
}
