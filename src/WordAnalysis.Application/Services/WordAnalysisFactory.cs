using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Services.Interfaces;

namespace WordAnalysis.Application.Services
{
    public class WordAnalysisFactory : IWordAnalysisFactory
    {
        public IWordAnalysisService GetWordAnalyser(string fileName, byte[] fileContent)
        {
            string fileExtension = Path.GetExtension(fileName);
            if(fileExtension == ".csv")
            {
                return new CSVWordAnalysisService(fileContent);
            }

            return null;
        }
    }
}
