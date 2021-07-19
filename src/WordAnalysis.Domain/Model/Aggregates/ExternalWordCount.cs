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

        public ExternalWordCount(string fileLink, FileType fileType, string sourceLanguage, string callbackUrl, string serviceRequestId, WordCount totalWordCount)
        {
            FileLink = fileLink ?? throw new ArgumentNullException(nameof(fileLink));
            FileType = fileType;
            SourceLanguage = sourceLanguage ?? throw new ArgumentNullException(nameof(sourceLanguage));
            CallbackUrl = callbackUrl ?? throw new ArgumentNullException(nameof(callbackUrl));
            ServiceRequestId = serviceRequestId ?? throw new ArgumentNullException(nameof(serviceRequestId));
            TotalWordCount = totalWordCount ?? throw new ArgumentNullException(nameof(totalWordCount));
        }

        public ExternalWordCount(string fileLink, FileType fileType, string sourceLanguage, string callbackUrl, string serviceRequestId)
            : this(fileLink, fileType, sourceLanguage, callbackUrl, serviceRequestId, new WordCount())
        {
        }

    }
}
