using System.ComponentModel.DataAnnotations;

namespace CashFlow.Api.Models;

public class TransactionCreatedViewModel
{
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Amount { get; set; }
}
