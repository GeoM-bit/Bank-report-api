using Microsoft.EntityFrameworkCore;

namespace BankReport.Context
{
    public class ReportBankDbContext: DbContext
    {
        public ReportBankDbContext(DbContextOptions<ReportBankDbContext> options): base(options)
        {}
    }
}
