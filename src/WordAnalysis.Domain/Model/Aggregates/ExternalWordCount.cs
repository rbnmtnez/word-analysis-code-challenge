using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Model.ValueObjects;

namespace WordAnalysis.Domain.Model.Aggregates
{
    public class ExternalWordCount
    {
        public string FileLink { get; set; }

        public FileType FileType { get; set; }

        public string SourceLanguage { get; set; }

        public string CallbackUrl { get; set; }

        public string ServiceRequestId { get; set; }

        public WordCount TotalWordCount { get; set; }
    }
}
