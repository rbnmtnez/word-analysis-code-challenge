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
    public class QueueStorageRepository<T> : IQueueStorageRepository<T> where T : IQueueEntity
    {
        public Task<T> DequeueAndRemoveItemAsync(string connectionString, string queueName)
        {
            throw new NotImplementedException();
        }

        public async Task QueueItemAsync(string connectionString, string queueName, T item)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            queueClient.CreateIfNotExists();

            await queueClient.SendMessageAsync(JsonConvert.SerializeObject(item));
        }
    }
}
