using AutoMapper;
using BankReport.DatabaseModels;
using BankReport.Logic.DtoModels;

namespace BankReport.Controllers.Mappers
{
    public class TransactionProfile:Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
