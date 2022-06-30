using BankReport.Context;
using BankReport.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace BankReport.Logic.Repositories
{
    public class AccountRepository : IRepository<Account,guid>
    {
        private ReportBankDbContext context;

        public AccountRepository(ReportBankDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Account> GetAll()
        {
            return (IQueryable<Account>)context.Accounts.ToList();
        }

        public Account GetById(Guid id)
        {
            return context.Accounts.Find(id);
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

    }
    
}
