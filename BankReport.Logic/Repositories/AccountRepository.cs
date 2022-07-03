using BankReport.Context;
using BankReport.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace BankReport.Logic.Repositories
{
    public class AccountRepository : IRepositoryAccount<Account,Guid>
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
            await this.Save();
        }
        
        public async Task Put(Guid id, Account account)
        {
            var accountFromDb= await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            accountFromDb.Currency = account.Currency;
            accountFromDb.Iban= account.Iban;   
            accountFromDb.AccountType = account.AccountType;
            _context.Accounts.Update(accountFromDb);
            await this.Save();
        }

        public async Task Delete(Guid id)
        {
            var accountFromDb = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            _context.Accounts.Remove(accountFromDb);
            await this.Save();
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }

    }
    
}
