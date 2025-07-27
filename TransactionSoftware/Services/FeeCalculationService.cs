using TransactionSoftware.Models;
using TransactionSoftware.Rules;

namespace TransactionSoftware.Services
{
    public class FeeCalculationService
    {
        private readonly IEnumerable<FeeRuleInterface> rules;

        public FeeCalculationService(IEnumerable<FeeRuleInterface> rules)
        {
            this.rules = rules;
        }

        public TransactionResponse Calculate(TransactionRequest transactionRequest)
        {
            var applied = rules.Where(r => r.IsMatch(transactionRequest))
                .Select(r => r.GetRuleInformation(transactionRequest))
                .ToList();

            var totalFee = applied.Sum(r => r.Fee);

            return new TransactionResponse
            {
                TransactionResponseId = transactionRequest.TransactionRequestId,
                CalculatedFee = totalFee,
                AppliedRules = applied
            };
        }

        public List<TransactionResponse> CalculateBatch(List<TransactionRequest> transactions) 
        {
            return transactions.AsParallel().Select(Calculate).ToList();
        }
    }
}
