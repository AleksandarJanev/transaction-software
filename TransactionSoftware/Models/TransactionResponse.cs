namespace TransactionSoftware.Models
{
    public class TransactionResponse
    {
        public string TransactionResponseId { get; set; }
        public decimal CalculatedFee { get; set; }
        public List<AppliedRuleInfo> AppliedRules { get; set; }
    }
}
