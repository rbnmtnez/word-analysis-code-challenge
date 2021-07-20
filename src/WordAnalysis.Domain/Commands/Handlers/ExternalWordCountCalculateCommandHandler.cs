using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Exceptions;
using WordAnalysis.Domain.Model.Aggregates;
using WordAnalysis.Domain.Services.Interfaces;

namespace WordAnalysis.Domain.Commands.Handlers
{
    public class ExternalWordCountCalculateCommandHandler : ICommandHandler<ExternalWordCountCalculateCommand, ExternalWordCount>
    {
        private readonly IWordAnalysisFileDownloaderService _wordAnalysisFileDownloaderService;
        private readonly IWordAnalysisFactory _wordAnalysisFactory;
        private readonly IWordAnalysisReplyService _wordAnalysisReplyService;

        public ExternalWordCountCalculateCommandHandler(IWordAnalysisFileDownloaderService wordAnalysisFileDownloaderService, IWordAnalysisFactory wordAnalysisFactory, IWordAnalysisReplyService wordAnalysisReplyService)
        {
            _wordAnalysisFileDownloaderService = wordAnalysisFileDownloaderService ?? throw new ArgumentNullException(nameof(wordAnalysisFileDownloaderService));
            _wordAnalysisFactory = wordAnalysisFactory ?? throw new ArgumentNullException(nameof(wordAnalysisFactory));
            _wordAnalysisReplyService = wordAnalysisReplyService ?? throw new ArgumentNullException(nameof(wordAnalysisReplyService));
        }

        public async Task<ExternalWordCount> ExecuteAsync(ExternalWordCountCalculateCommand command)
        {
            ExternalWordCount result = new(
                fileLink: command.FileLink,
                fileType: command.FileType,
                status: Model.ValueObjects.Status.Succeeded,
                sourceLanguage: command.SourceLanguage,
                callbackUrl: command.CallbackUrl,
                serviceRequestId: command.ServiceRequestId
             );

            try
            {
                byte[] fileContent = await _wordAnalysisFileDownloaderService.DownloadFileAsync(command.FileLink);

                string fileName = Path.GetFileName(new Uri(command.FileLink).LocalPath);
                IWordAnalysisService wordAnalyser = _wordAnalysisFactory.GetWordAnalyser(fileName, fileContent);
                if(wordAnalyser == null)
                {
                    result.Status = Model.ValueObjects.Status.FormatNotSupported;
                    result.AddErrorMessage($"Format not supported, analyser not available for url {command.FileLink}");
                }
                else
                {
                    WordCountAnalysis wordCountAnalysis = wordAnalyser.GetWordCountAnalysis();
                    result.TotalWordCount = wordCountAnalysis.GetSummary();
                }
            }
            catch (HttpRequestException ex)
            {
                result.Status =
                    ex.StatusCode == System.Net.HttpStatusCode.NotFound ?
                    Model.ValueObjects.Status.DocumentNotFound
                    : Model.ValueObjects.Status.Failed;
                result.AddErrorMessage($"Error getting file from url {command.FileLink}");
            }
            catch (Exception)
            {
                result.Status = Model.ValueObjects.Status.Failed;
                result.AddErrorMessage($"Error processing external word count calculation for url {command.FileLink}");
            }

            await _wordAnalysisReplyService.SendWordAnalysisResultsAsync(result, command.CallbackUrl);

            return result;
        }

    }
}
