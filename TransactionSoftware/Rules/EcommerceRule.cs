using TransactionSoftware.Models;

namespace TransactionSoftware.Rules
{
    public class EcommerceRule : FeeRuleInterface
    {
        public decimal CalculateFee(TransactionRequest transaction)
        {
            decimal fee = (transaction.Amount * 0.018m) + 0.15m;
            if (fee > 120)
            {
                return 120;
            }
            else return fee;
        }

        public AppliedRuleInfo GetRuleInformation(TransactionRequest transaction)
        {
            return new()
            {
                AppliedRuleName = "Rule 2",
                AppliedRuleDescription = "1.8% + 0.15€, no more than 120€ for e-commerce",
                Fee = CalculateFee(transaction)
            };
        }

        public bool IsMatch(TransactionRequest transaction)
        {
            return transaction.TransactionRequestType == "e-commerce";
        }
    }
}
