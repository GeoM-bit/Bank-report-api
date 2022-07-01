using BankReport.Context;
using BankReport.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace BankReport.Logic.Repositories
{
    public class TransactionRepository:IRepositoryTransaction<Transaction, Guid>
    {
        private readonly ReportBankDbContext _context;

        public TransactionRepository(ReportBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAll()
        {
            var result = await _context.Transactions.ToListAsync();

            return result;
        }

        public async Task<Transaction> GetById(Guid id)
        {
            var result = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task Post(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            this.Save();
        }

        public async Task Put(Guid id, Transaction transaction)
        {
            var transactionFromDb = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            transactionFromDb.Amount= transaction.Amount;
            transactionFromDb.CategoryTransaction= transaction.CategoryTransaction;
            transactionFromDb.TransactionDate = transaction.TransactionDate;
            _context.Transactions.Update(transactionFromDb);
            this.Save();
        }

        public async Task Delete(Guid id)
        {
            var transactionFromDb = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            _context.Transactions.Remove(transactionFromDb);
            this.Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
