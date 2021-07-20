using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Commands;

namespace WordAnalysis.Jobs.Services
{
    public interface IWordAnalysisJobService
    {
        Task ProcessExternalWordCountCalculateCommandAsync(ExternalWordCountCalculateCommand command);
    }
}
