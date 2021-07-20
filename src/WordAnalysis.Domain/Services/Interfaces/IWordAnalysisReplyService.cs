using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Model.Aggregates;

namespace WordAnalysis.Domain.Services.Interfaces
{
    public interface IWordAnalysisReplyService
    {
        Task SendWordAnalysisResultsAsync(ExternalWordCount analysisResults, string url);
    }
}
