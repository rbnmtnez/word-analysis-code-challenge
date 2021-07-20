using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Services.Interfaces;

namespace WordAnalysis.Infrastructure.Repositories
{
    public class WordAnalysisFileDownloaderRepository : IWordAnalysisFileDownloaderService
    {
        private readonly HttpClient _httpClient;

        //TODO > REVIEW LOGGER NOT WORKING
        //private readonly ILogger _logger;

        public WordAnalysisFileDownloaderRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<byte[]> DownloadFileAsync(string url)
        {
            byte[] file = await _httpClient.GetByteArrayAsync(url);
            return file;
        }
    }
}
