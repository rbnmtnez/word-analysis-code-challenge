using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Exceptions
{
    public class WordAnalysisWrongFileException : Exception
    {
        public WordAnalysisWrongFileException(string message) : base(message)
        {
        }
    }
}
