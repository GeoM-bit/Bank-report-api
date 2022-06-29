using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReport.DatabaseModels
{
    public class Account
    {
        public Guid Id { get; set; }
        public _AccountType AccountType { get; set; }
        public string Iban { get; set; }
        public string QwnerName { get; set; }
        public string Currency { get; set; }

    }

    public enum _AccountType
    {
        Debit,
        Credit
    }
}
