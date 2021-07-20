using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordAnalysis.API.DTOs;
using WordAnalysis.API.Services;

namespace WordAnalysis.Host.Controllers
{
    [ApiController]
    public class WordCountAnalyticsController : ControllerBase
    {

        private readonly IWordService _wordService;

        public WordCountAnalyticsController(IWordService wordService)
        {
            _wordService = wordService ?? throw new ArgumentNullException(nameof(wordService));
        }


        /// <summary>
        /// Performing word count analysis for external file
        /// </summary>
        /// <param name="body"></param>
        /// <response code="201">Success</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [Route("/api/external")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ApiExternalPostAsync([FromBody] ExternalCountCalculate body)
        {
            await _wordService.WordCountExternalAnalysisAsync(body);
            return StatusCode(201);
        }
    }
}
