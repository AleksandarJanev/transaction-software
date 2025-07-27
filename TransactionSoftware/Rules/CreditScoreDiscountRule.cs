using TransactionSoftware.Models;

namespace TransactionSoftware.Rules
{
    public class CreditScoreDiscountRule : FeeRuleInterface
    {
        public decimal CalculateFee(TransactionRequest transaction)
        {
            return -(transaction.Amount * 0.1m);
        }

        public AppliedRuleInfo GetRuleInformation(TransactionRequest transaction)
        {
            return new AppliedRuleInfo()
            {
                AppliedRuleName = "Rule #3",
                AppliedRuleDescription = "1% discount amount when credit score > 400",
                Fee = CalculateFee(transaction)
            };
        }

        public bool IsMatch(TransactionRequest transaction)
        {
            return transaction.CreditScore > 400;
        }
    }
}
