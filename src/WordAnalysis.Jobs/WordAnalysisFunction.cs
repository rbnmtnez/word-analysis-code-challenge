using System;
using Newtonsoft.Json;
using WordAnalysis.Domain.Commands;
using Microsoft.Azure.Functions.Worker;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WordAnalysis.Jobs.Services;

namespace WordAnalysis.Jobs
{
    public class WordAnalysisFunction
    {
        private readonly IWordAnalysisJobService _wordAnalysisJobService;

        public WordAnalysisFunction(IWordAnalysisJobService wordAnalysisJobService)
        {
            _wordAnalysisJobService = wordAnalysisJobService ?? throw new ArgumentNullException(nameof(wordAnalysisJobService));
        }

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
                await _wordAnalysisJobService.ProcessExternalWordCountCalculateCommandAsync(command);
            }
            catch(Exception ex)
            {
                logger.LogError($"Error processing word analysis command", ex);
                throw;
            }
        }
    }
}
