using TransactionSoftware.Models;

namespace TransactionSoftware.Rules
{
    public interface FeeRuleInterface
    {
        bool IsMatch(TransactionRequest transaction);
        decimal CalculateFee(TransactionRequest transaction);
        AppliedRuleInfo GetRuleInformation(TransactionRequest transaction);
    }
}
