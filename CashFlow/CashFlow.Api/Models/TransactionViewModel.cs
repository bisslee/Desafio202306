using System.ComponentModel.DataAnnotations;

namespace CashFlow.Api.Models
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
