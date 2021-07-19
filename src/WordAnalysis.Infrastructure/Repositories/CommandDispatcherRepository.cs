using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Commands;
using WordAnalysis.Domain.Services.Interfaces;
using WordAnalysis.Infrastructure.Model;
using WordAnalysis.Infrastructure.Repositories.QueueStorage;

namespace WordAnalysis.Infrastructure.Repositories
{
    public class CommandDispatcherRepository<TCommand, TResult> : ICommandDispatcherService<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        private readonly IQueueStorageRepository<IQueueEntity> _queueStorageRepository;
        private readonly QueueStorageOptions _queueStorageOptions;

        public CommandDispatcherRepository(IQueueStorageRepository<IQueueEntity> queueStorageRepository, IOptions<QueueStorageOptions> queueStorageOptions)
        {
            _queueStorageRepository = queueStorageRepository ?? throw new ArgumentNullException(nameof(queueStorageRepository));

            if (queueStorageOptions == null || queueStorageOptions.Value == null) throw new ArgumentNullException(nameof(queueStorageOptions));
            _queueStorageOptions = queueStorageOptions.Value;
        }

        public async Task DispatchAsync(TCommand command)
        {
            await _queueStorageRepository.QueueItemAsync(_queueStorageOptions.ConnectionString, _queueStorageOptions.QueueName, command);
        }
    }
}
