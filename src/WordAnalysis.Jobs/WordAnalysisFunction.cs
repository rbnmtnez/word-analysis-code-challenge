using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace WordAnalysis.Jobs
{
    public static class WordAnalysisFunction
    {
        [FunctionName("processWordAnalysisCommand")]
        public static void Run([QueueTrigger("%ConnectionStrings:QueueStorageQueueName%", Connection = "ConnectionStrings:QueueStorageConnectionString")]string myQueueItem, ILogger log)
        {
            //TODO > MAKE ASYNC 

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
