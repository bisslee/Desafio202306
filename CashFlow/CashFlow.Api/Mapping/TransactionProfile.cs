using AutoMapper;
using CashFlow.Api.Models;
using CashFlow.Domain.Models;

namespace CashFlow.Api
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionViewModel>().ReverseMap();
            CreateMap<Transaction, TransactionCreatedViewModel>().ReverseMap();
            CreateMap<Transaction, TransactionUpdatedViewModel>().ReverseMap();
            CreateMap<Balance, BalanceViewModel>().ReverseMap();
        }
    }
}
