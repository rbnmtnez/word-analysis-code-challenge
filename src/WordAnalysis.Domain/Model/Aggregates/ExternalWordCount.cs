using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordAnalysis.Domain.Model.ValueObjects;

namespace WordAnalysis.Domain.Model.Aggregates
{
    public class ExternalWordCount
    {
        public string FileLink { get; set; }

        public FileType FileType { get; set; }

        public Status Status { get; set; }

        public string SourceLanguage { get; set; }

        public string CallbackUrl { get; set; }

        public string ServiceRequestId { get; set; }

        private List<string> _messages;
        public string Messages { 
            get {
                return _messages != null ? string.Join(";", _messages) : null;
            }
        }

        public WordCount TotalWordCount { get; set; }

        public ExternalWordCount(string fileLink, FileType fileType, Status status, string sourceLanguage, string callbackUrl, string serviceRequestId, WordCount totalWordCount)
        {
            FileLink = fileLink ?? throw new ArgumentNullException(nameof(fileLink));
            FileType = fileType;
            Status = status;
            SourceLanguage = sourceLanguage ?? throw new ArgumentNullException(nameof(sourceLanguage));
            CallbackUrl = callbackUrl ?? throw new ArgumentNullException(nameof(callbackUrl));
            ServiceRequestId = serviceRequestId ?? throw new ArgumentNullException(nameof(serviceRequestId));
            TotalWordCount = totalWordCount ?? throw new ArgumentNullException(nameof(totalWordCount));
        }

        public ExternalWordCount(string fileLink, FileType fileType, Status status, string sourceLanguage, string callbackUrl, string serviceRequestId)
            : this(fileLink, fileType, status, sourceLanguage, callbackUrl, serviceRequestId, new WordCount())
        {
        }

        public void AddErrorMessage(string message)
        {
            _messages ??= new List<string>();
            _messages.Add(message);
        }

    }
}
