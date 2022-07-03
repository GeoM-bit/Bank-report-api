namespace BankReport.Logic.DtoModels
{
    public class TransactionReport
    {
        public CategoryTransaction categoryName { get; set; }
        public double totalAmount { get; set; }
        public string currency { get; set; }

        public DateTimeOffset transactDate { get; set; }
    }
    
}
