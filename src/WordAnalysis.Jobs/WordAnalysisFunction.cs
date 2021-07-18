using System;
using Newtonsoft.Json;
using WordAnalysis.Domain.Commands;
using Microsoft.Azure.Functions.Worker;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WordAnalysis.Jobs
{
    public class WordAnalysisFunction
    {
        [Function("processWordAnalysisCommand")]
        public async Task ProcessWordAnalysisCommandAsync(
            [QueueTrigger("%ConnectionStrings:QueueStorageQueueName%", Connection = "ConnectionStrings:QueueStorageConnectionString")]string queueItem,
            FunctionContext context)
        {
            ILogger logger = context.GetLogger("ProcessWordAnalysisCommand");
            try
            {
                logger.LogInformation($"C# Queue trigger function processed: {queueItem}");

                ExternalWordCountCalculateCommand command = JsonConvert.DeserializeObject<ExternalWordCountCalculateCommand>(queueItem);

            }
            catch(Exception ex)
            {
                logger.LogError($"Error processing word analysis command", ex);
                throw;
            }
        }
    }
}
