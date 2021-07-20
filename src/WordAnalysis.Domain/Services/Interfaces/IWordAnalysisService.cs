using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Model.Aggregates;

namespace WordAnalysis.Domain.Services.Interfaces
{
    public interface IWordAnalysisService
    {
        WordCountAnalysis GetWordCountAnalysis();
    }
}
