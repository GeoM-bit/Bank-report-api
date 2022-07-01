using BankReport.Context;
using BankReport.DatabaseModels;
using BankReport.Logic.DtoModels;
using Microsoft.EntityFrameworkCore;

namespace BankReport.Logic.Repositories
{
    public class AccountRepository : IRepository<Account,Guid>
    {
        private readonly ReportBankDbContext _context;

        public AccountRepository(ReportBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAll()
        {
            var result = await _context.Accounts.ToListAsync();

            return result;
        }

        public async Task<Account> GetById(Guid id)
        {
           var result = await _context.Accounts.FirstOrDefaultAsync(x => x.Id==id);

           return result;
        }

        public async Task Post(Account account)
        {
            await _context.Accounts.AddAsync(account);
            this.Save();
        }
        
        public async Task Put(Guid id, Account account)
        {
            var accountFromDb= await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            accountFromDb.Currency = account.Currency;
            accountFromDb.Iban= account.Iban;   
            accountFromDb.AccountType = account.AccountType;
            _context.Accounts.Update(accountFromDb);
            this.Save();
        }

        public async Task Delete(Guid id)
        {
            var accountFromDb = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            _context.Accounts.Remove(accountFromDb);
            this.Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
    
}
