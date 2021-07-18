using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Commands;
using WordAnalysis.Domain.Model.Aggregates;

namespace WordAnalysis.Jobs.Services
{
    public class WordAnalyticsJobService : IWordAnalyticsJobService
    {
        private readonly ICommandHandler<ExternalWordCountCalculateCommand, ExternalWordCount> _externalWordCountCalculateCommandHandler;

        public WordAnalyticsJobService(ICommandHandler<ExternalWordCountCalculateCommand, ExternalWordCount> externalWordCountCalculateCommandHandler)
        {
            _externalWordCountCalculateCommandHandler = externalWordCountCalculateCommandHandler ?? throw new ArgumentNullException(nameof(externalWordCountCalculateCommandHandler));
        }

        public async Task ProcessExternalWordCountCalculateCommandAsync(ExternalWordCountCalculateCommand command)
        {
            await _externalWordCountCalculateCommandHandler.ExecuteAsync(command);
        }
    }
}
