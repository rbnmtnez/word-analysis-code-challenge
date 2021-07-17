using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.API.DTOs;

namespace WordAnalysis.API.Services
{
    public interface IWordService
    {
        Task WordCountExternalAnalysisAsync(ExternalCountCalculate externalCountCalculate);
    }
}
