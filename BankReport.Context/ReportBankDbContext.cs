using BankReport.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace BankReport.Context
{
    public class ReportBankDbContext: DbContext
    {
        public ReportBankDbContext(DbContextOptions<ReportBankDbContext> options): base(options)
        {}

        public DbSet<Account> Accounts { get; set; }
    }
}
