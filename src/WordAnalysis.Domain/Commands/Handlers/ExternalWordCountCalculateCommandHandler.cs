using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Model.Aggregates;

namespace WordAnalysis.Domain.Commands.Handlers
{
    public class ExternalWordCountCalculateCommandHandler : ICommandHandler<ExternalWordCountCalculateCommand, ExternalWordCount>
    {
        public async Task<ExternalWordCount> ExecuteAsync(ExternalWordCountCalculateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
