using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Model.Aggregates;
using WordAnalysis.Domain.Model.ValueObjects;

namespace WordAnalysis.Domain.Commands
{
    public class ExternalWordCountCalculateCommand : BaseCommand<ExternalWordCount>
    {

        public readonly string FileLink;

        public readonly FileType FileType;

        public readonly string SourceLanguage;

        public readonly string CallbackUrl;

        public readonly string ServiceRequestId;

        public ExternalWordCountCalculateCommand(string fileLink, FileType fileType, string sourceLanguage, string callbackUrl, string serviceRequestId) : base()
        {
            FileLink = fileLink ?? throw new ArgumentNullException(nameof(fileLink));
            FileType = fileType;
            SourceLanguage = sourceLanguage ?? throw new ArgumentNullException(nameof(sourceLanguage));
            CallbackUrl = callbackUrl ?? throw new ArgumentNullException(nameof(callbackUrl));
            ServiceRequestId = serviceRequestId ?? throw new ArgumentNullException(nameof(serviceRequestId));
        }
    }
}
