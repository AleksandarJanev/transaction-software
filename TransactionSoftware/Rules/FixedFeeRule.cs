using TransactionSoftware.Models;

namespace TransactionSoftware.Rules
{
    public class FixedFeeRule : FeeRuleInterface
    {
        public decimal CalculateFee(TransactionRequest transaction)
        {
            if(transaction.Amount < 100)
            {
                return 0.20m;
            }
            return transaction.Amount * 0.002m;
        }

        public AppliedRuleInfo GetRuleInformation(TransactionRequest transaction)
        {
            return new()
            {
                AppliedRuleName = "Rule 1",
                AppliedRuleDescription = "Fixed or percent fee for POS transactions",
                Fee = CalculateFee(transaction)
            };
        }

        public bool IsMatch(TransactionRequest transaction)
        {
            return transaction.TransactionRequestType == "pos";
        }
    }
}
