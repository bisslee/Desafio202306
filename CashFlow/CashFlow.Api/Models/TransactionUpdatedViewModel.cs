using System.ComponentModel.DataAnnotations;

namespace CashFlow.Api.Models
{
    public class TransactionUpdatedViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }

    }
}
