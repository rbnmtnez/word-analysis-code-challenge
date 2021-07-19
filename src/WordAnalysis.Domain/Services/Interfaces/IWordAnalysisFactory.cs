using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Services.Interfaces
{
    public interface IWordAnalysisFactory
    {
        IWordAnalysisService GetWordAnalyser(string fileName, byte[] fileContent);
    }
}
