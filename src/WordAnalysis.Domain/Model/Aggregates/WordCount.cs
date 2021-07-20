using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Model.Aggregates
{
    public class WordCount
    {
        public int Repetitions { get; set; }

        public int ContextMatch { get; set; }

        public int PercentMatch100 { get; set; }

        public int PercentMatch95To99 { get; set; }

        public int PercentMatch85To94 { get; set; }

        public int PercentMatch75To84 { get; set; }

        public int PercentMatch50To74 { get; set; }

        public int NoMatch { get; set; }

        public int Total { 
            get =>
                Repetitions +
                ContextMatch + 
                PercentMatch100 + 
                PercentMatch95To99 + 
                PercentMatch85To94 + 
                PercentMatch75To84 + 
                PercentMatch50To74 + 
                NoMatch;
        }

        public WordCount(int repetitions, int contextMatch, int percentMatch100, int percentMatch95To99, int percentMatch85To94, int percentMatch75To84, int percentMatch50To74, int noMatch)
        {
            Repetitions = repetitions;
            ContextMatch = contextMatch;
            PercentMatch100 = percentMatch100;
            PercentMatch95To99 = percentMatch95To99;
            PercentMatch85To94 = percentMatch85To94;
            PercentMatch75To84 = percentMatch75To84;
            PercentMatch50To74 = percentMatch50To74;
            NoMatch = noMatch;
        }

        public WordCount()
        {
        }
    }
}
