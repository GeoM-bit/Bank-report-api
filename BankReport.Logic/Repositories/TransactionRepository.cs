using BankReport.Context;
using BankReport.DatabaseModels;
using BankReport.Logic.DtoModels;
using Microsoft.EntityFrameworkCore;

namespace BankReport.Logic.Repositories
{
    public class TransactionRepository:IRepositoryTransaction<Transaction, Guid, List<TransactionReport>>
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
            await this.Save();
        }

        public async Task Put(Guid id, Transaction transaction)
        {
            var transactionFromDb = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            transactionFromDb.Amount= transaction.Amount;
            transactionFromDb.CategoryTransaction= transaction.CategoryTransaction;
            transactionFromDb.TransactionDate = transaction.TransactionDate;
            _context.Transactions.Update(transactionFromDb);
            await this.Save();
        }

        public async Task Delete(Guid id)
        {
            var transactionFromDb = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            _context.Transactions.Remove(transactionFromDb);
            await this.Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

         public async Task<List<TransactionReport>> Report(Guid id)
         {
             var previousMonth = DateTimeOffset.Now.AddMonths(-1).Month;
            
             var result = await
                 (from transaction in _context.Transactions
                  where (transaction.AccountId == id)
                  group transaction by new TransactionReport
                  {
                      categoryName = (DtoModels.CategoryTransaction)transaction.CategoryTransaction,
                      currency = transaction.Account.Currency,
                      transactDate = transaction.TransactionDate,
                  } into g
                  select new TransactionReport
                  {
                      categoryName = g.Key.categoryName,
                      totalAmount = g.Sum(x => x.Amount),
                      currency = g.Key.currency,
                      transactDate=g.Key.transactDate
                  }
                  ).ToListAsync();
            var results =  result.Where(x => x.transactDate.Month == previousMonth).ToList();
           
            return results;
         }

    }
}
