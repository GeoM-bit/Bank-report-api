namespace BankReport.DatabaseModels
{
    public class Account
    {
        public Guid Id { get; set; }
        public AccountType AccountType { get; set; }
        public string Iban { get; set; }
        public string QwnerName { get; set; }
        public string Currency { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }

    public enum AccountType
    {
        Debit=1,
        Credit=2
    }
}
