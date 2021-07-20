using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Exceptions
{
    public class WordAnalysisFileNotFoundException : Exception
    {
        public WordAnalysisFileNotFoundException(string filePath) : base($"Word Analysis file {filePath} not found")
        {
        }
    }
}
