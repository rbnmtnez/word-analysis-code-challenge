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

        public ExternalWordCountCalculateCommandHandler(IWordAnalysisFileDownloaderService wordAnalysisFileDownloaderService, IWordAnalysisFactory wordAnalysisFactory)
        {
            _wordAnalysisFileDownloaderService = wordAnalysisFileDownloaderService ?? throw new ArgumentNullException(nameof(wordAnalysisFileDownloaderService));
            _wordAnalysisFactory = wordAnalysisFactory ?? throw new ArgumentNullException(nameof(wordAnalysisFactory));
        }

        public async Task<ExternalWordCount> ExecuteAsync(ExternalWordCountCalculateCommand command)
        {
            this.ValidateCommand(command);
            return await this.ProcessCommandAsync(command);
        }

        private async Task<ExternalWordCount> ProcessCommandAsync(ExternalWordCountCalculateCommand command)
        {
            ExternalWordCount result = new(
                fileLink: command.FileLink,
                fileType: Model.ValueObjects.Status.Succeeded,
                sourceLanguage: command.SourceLanguage,
                callbackUrl: command.CallbackUrl,
                serviceRequestId: command.ServiceRequestId
             );

            try
            {
                byte[] fileContent = await _wordAnalysisFileDownloaderService.DownloadFileAsync(command.FileLink);

                string fileName = Path.GetFileName(new Uri(command.FileLink).LocalPath);
                IWordAnalysisService wordAnalyser = _wordAnalysisFactory.GetWordAnalyser(fileName, fileContent);

                WordCountAnalysis wordCountAnalysis = wordAnalyser.GetWordCountAnalysis();
                result.TotalWordCount = wordCountAnalysis.GetSummary();
            }
            catch (HttpRequestException ex)
            {
                result.FileType =
                    ex.StatusCode == System.Net.HttpStatusCode.NotFound ?
                    Model.ValueObjects.Status.DocumentNotFound
                    : Model.ValueObjects.Status.Failed;
            }
            catch (Exception ex)
            {
                result.FileType = Model.ValueObjects.Status.Failed;
            }

            await SendCallbackResultsAsync(result);

            return result;
        }

        private void ValidateCommand(ExternalWordCountCalculateCommand command)
        {
            //Enhancement: validations
        }

        private async Task SendCallbackResultsAsync(ExternalWordCount externalWordCount)
        {
            //TODO > IMPLEMENT
            throw new NotImplementedException();
        }

    }
}
