using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Infrastructure.Model;

namespace WordAnalysis.Infrastructure.Repositories.QueueStorage
{
    public interface IQueueStorageRepository<T> where T : IQueueEntity
    {
        Task<T> DequeueAndRemoveItemAsync(string connectionString, string queueName);

        Task QueueItemAsync(string connectionString, string queueName, T item);
    }
}
