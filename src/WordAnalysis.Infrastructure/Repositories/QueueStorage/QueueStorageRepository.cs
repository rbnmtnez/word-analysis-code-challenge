using Azure.Storage.Queues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Infrastructure.Model;

namespace WordAnalysis.Infrastructure.Repositories.QueueStorage
{
    public class QueueStorageRepository<T> : IQueueStorageRepository<T> where T : class
    {
        public Task<T> DequeueAndRemoveItemAsync(string connectionString, string queueName)
        {
            throw new NotImplementedException();
        }

        public async Task QueueItemAsync(string connectionString, string queueName, object item)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName, new QueueClientOptions() { MessageEncoding = QueueMessageEncoding.Base64 });

            queueClient.CreateIfNotExists();

            await queueClient.SendMessageAsync(JsonConvert.SerializeObject(item));
        }
    }
}
