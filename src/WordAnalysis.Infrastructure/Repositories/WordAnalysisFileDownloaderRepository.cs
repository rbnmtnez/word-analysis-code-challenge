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


        public WordAnalysisFileDownloaderRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<byte[]> DownloadFileAsync(string url)
        {
            byte[] file = await _httpClient.GetByteArrayAsync(url);
            return file;
        }
    }
}
