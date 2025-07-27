using TransactionSoftware.Models;

namespace TransactionSoftware.Services
{
    public class HistoryService
    {
        public readonly List<(TransactionRequest, TransactionResponse)> store = [];

        public void Log(TransactionRequest req, TransactionResponse res)
        {
            store.Add((req, res));
        }

        public IEnumerable<object> GetHistory()
        {
            return store.Select(x => new {
                Input = x.Item1,
                Output = x.Item2
            });
        }
    }
}
