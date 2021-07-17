using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Model.Aggregates
{
    public class WordCount
    {
        public int? Repetitions { get; set; }

        public int? ContextMatch { get; set; }

        public int? PercentMatch100 { get; set; }

        public int? PercentMatch95To99 { get; set; }

        public int? PercentMatch85To94 { get; set; }

        public int? PercentMatch75To84 { get; set; }

        public int? PercentMatch50To74 { get; set; }

        public int? NoMatch { get; set; }

        public int? Total { get; set; }
    }
}
