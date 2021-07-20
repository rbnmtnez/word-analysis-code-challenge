using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.API.DTOs;
using WordAnalysis.Domain.Commands;
using WordAnalysis.Domain.Model.Aggregates;
using WordAnalysis.Domain.Services.Interfaces;

namespace WordAnalysis.API.Services
{
    public class WordService : IWordService
    {
        private readonly ICommandDispatcherService<ExternalWordCountCalculateCommand, ExternalWordCount> _externalWordCountCommandDispatcher;
        private readonly IMapper _mapper;

        public WordService(ICommandDispatcherService<ExternalWordCountCalculateCommand, ExternalWordCount> externalWordCountCommandDispatcher, IMapper mapper)
        {
            _externalWordCountCommandDispatcher = externalWordCountCommandDispatcher ?? throw new ArgumentNullException(nameof(externalWordCountCommandDispatcher));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task WordCountExternalAnalysisAsync(ExternalCountCalculate externalCountCalculate)
        {
            ExternalWordCountCalculateCommand command = _mapper.Map<ExternalCountCalculate, ExternalWordCountCalculateCommand>(externalCountCalculate);
            await _externalWordCountCommandDispatcher.DispatchAsync(command);
        }

    }
}
