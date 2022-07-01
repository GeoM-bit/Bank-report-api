using AutoMapper;
using BankReport.DatabaseModels;
using BankReport.Logic.DtoModels;

namespace BankReport.Controllers.Mappers
{
    public class AccountProfile:Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>();
        }
    }
}
