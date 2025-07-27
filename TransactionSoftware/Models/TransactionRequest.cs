namespace TransactionSoftware.Models
{
    public class TransactionRequest
    {
        public string TransactionRequestId { get; set; }
        public string TransactionRequestType { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int CreditScore { get; set; }
    }
}
