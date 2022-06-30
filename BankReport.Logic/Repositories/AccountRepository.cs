using AutoMapper;
using BankReport.Context;
using BankReport.DatabaseModels;
using BankReport.Logic.DtoModels;
using Microsoft.EntityFrameworkCore;

namespace BankReport.Logic.Repositories
{
    public class AccountRepository : IRepository<Account,AccountDto,Guid>
    {
        private ReportBankDbContext context;

        Mapper mapper = new Mapper(new MapperConfiguration(cfg=>cfg.CreateMap<Account,AccountDto>()));
        public AccountRepository(ReportBankDbContext context)
        {
            this.context = context;
        }

        public IQueryable<AccountDto> GetAll()
        {
            List <AccountDto> results= new List<AccountDto>();
            foreach(var element in (IQueryable<Account>)context.Accounts.ToList())
            {
                results.Add(mapper.Map<AccountDto>(element));
            }
            return results.AsQueryable();
        }

        public AccountDto GetById(Guid id)
        {
            return mapper.Map<AccountDto>(context.Accounts.Find(id));
        }

        public void Post(Account account)
        {
            context.Accounts.Add(account);
        }
        
        public void Put(Guid id)
        {
            Account account=context.Accounts.Find(id);
            context.Entry(account).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Account account = context.Accounts.Find(id);
            context.Accounts.Remove(account);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
    
}
