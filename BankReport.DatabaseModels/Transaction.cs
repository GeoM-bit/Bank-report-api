using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReport.DatabaseModels
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public _CategoryTransaction CategoryTransaction { get; set; }
        public DateTimeOffset TransactionDate { get; set; }

        public Account AccountId { get; set; }
        
    }

    public enum _CategoryTransaction
    {
        Food=1,
        Entertainment,
        Clothing,
        Travel,
        MedicalExpenses
    }
}
