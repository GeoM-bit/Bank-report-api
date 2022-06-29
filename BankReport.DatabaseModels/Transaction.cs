namespace BankReport.DatabaseModels
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public double Amount { get; set; }
        public CategoryTransaction CategoryTransaction { get; set; }
        public DateTimeOffset TransactionDate { get; set; }

        public virtual Account Account { get; set; }


        
    }

    public enum CategoryTransaction
    {
        Food=1,
        Entertainment=2,
        Clothing=3,
        Travel=4,
        MedicalExpenses=5
    }
}
