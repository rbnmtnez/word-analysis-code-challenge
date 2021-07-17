using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.API.DTOs;
using WordAnalysis.Domain.Commands;
using WordAnalysis.Domain.Model.ValueObjects;

namespace WordAnalysis.API.Adapters.MapperProfiles
{
    public class WordCountAnalyticsMappingProfile : Profile
    {
        public WordCountAnalyticsMappingProfile()
        {
            CreateMap<ExternalCountCalculate, ExternalWordCountCalculateCommand>();
            CreateMap<ExternalFileType, FileType>();
        }
    }
}
