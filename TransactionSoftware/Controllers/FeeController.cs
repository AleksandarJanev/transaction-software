using Microsoft.AspNetCore.Mvc;
using TransactionSoftware.Models;
using TransactionSoftware.Services;

namespace TransactionSoftware.Controllers
{
    [ApiController]
    [Route("api/fees")]
    public class FeeController : ControllerBase
    {
        private readonly FeeCalculationService feeCalculationService;
        private readonly HistoryService historyService;

        public FeeController(FeeCalculationService calculator, HistoryService history)
        {
            feeCalculationService = calculator;
            historyService = history;
        }
        [HttpPost("calculate")]
        public IActionResult Caluculate([FromBody] TransactionRequest req)
        {
            var result = feeCalculationService.Calculate(req);
            historyService.Log(req, result);
            return Ok(result);
        }

        [HttpPost("calculateMultiple")]
        public IActionResult CalculateBatch([FromBody] List<TransactionRequest> transactions)
        {
            var result = feeCalculationService.CalculateBatch(transactions);
            transactions.Zip(result, (transaction, response) =>
            {
                historyService.Log(transaction, response);
                return 0;
            }).ToList();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetHistoryOfTransactions()
        {
            return Ok(historyService.GetHistory());
        }
    }
}
