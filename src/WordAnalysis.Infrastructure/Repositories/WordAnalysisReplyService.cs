using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Model.Aggregates;
using WordAnalysis.Domain.Services.Interfaces;

namespace WordAnalysis.Infrastructure.Repositories
{
    public class WordAnalysisReplyService: IWordAnalysisReplyService
    {
        private readonly HttpClient _httpClient;

        public WordAnalysisReplyService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task SendWordAnalysisResultsAsync(ExternalWordCount analysisResults, string url)
        {
            StringContent data = new(JsonConvert.SerializeObject(
                analysisResults,
                converters: new Newtonsoft.Json.Converters.StringEnumConverter()),
                Encoding.UTF8,
                "application/json");
            _ = await _httpClient.PostAsync(url, data);
        }
    }
}
