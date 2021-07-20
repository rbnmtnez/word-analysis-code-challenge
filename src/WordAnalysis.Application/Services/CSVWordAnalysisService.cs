using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordAnalysis.Domain.Exceptions;
using WordAnalysis.Domain.Model.Aggregates;
using WordAnalysis.Domain.Services.Interfaces;

namespace WordAnalysis.Application.Services
{
    public class CSVWordAnalysisService : IWordAnalysisService
    {
        private readonly byte[] fileContent;
        const string ANALYSIS_SECTION_START = "Analysis";
        const string ANALYSIS_SECTION_END = "------------------------------------------------------------------------------------";

        public CSVWordAnalysisService(byte[] fileContent)
        {
            this.fileContent = fileContent ?? throw new ArgumentNullException(nameof(fileContent));
        }

        public WordCountAnalysis GetWordCountAnalysis()
        {
            string stringFileContent = System.Text.Encoding.UTF8.GetString(fileContent, 0, fileContent.Length);
            stringFileContent = RemoveEmptyCharactersCSVFile(stringFileContent);

            string[] analysisSectionsContent = stringFileContent.Split(ANALYSIS_SECTION_END);

            WordCountAnalysis wordCountAnalysis = new();
            foreach (var analysisSectionContent in analysisSectionsContent)
            {
                if (!analysisSectionContent.StartsWith(ANALYSIS_SECTION_START)) continue;

                wordCountAnalysis.AddWordCount(this.GetWordCountFromAnalysisSection(analysisSectionContent));
            }

            if (wordCountAnalysis.GetWordCounts().Count == 0) throw new WordAnalysisWrongFileException("No word analysis sections found in csv file");

            return wordCountAnalysis;
        }

        private static string RemoveEmptyCharactersCSVFile(string stringFileContent)
        {
            return stringFileContent
                .Replace("\r\n", "")
                .Replace(" ", "")
                .Replace(";;;;;", "")
                .Trim();
        }

        private WordCount GetWordCountFromAnalysisSection(string analysisSectionContent)
        {
            int repetitions = GetAnalysisSectionValue(analysisSectionContent, "Repetition;[0-9]*;(?<Repetitions>[0-9]*);", "repetitions");
            int contextMatch = GetAnalysisSectionValue(analysisSectionContent, "101%;[0-9]*;(?<ContextMatch>[0-9]*);", "contextMatch");
            int percentMatch100 = GetAnalysisSectionValue(analysisSectionContent, "100%;[0-9]*;(?<PercentMatch100>[0-9]*);", "percent match 100");
            int percentMatch95To99 = GetAnalysisSectionValue(analysisSectionContent, "95%-99%;[0-9]*;(?<PercentMatch95To99>[0-9]*);", "percent match 95 to 99");
            int percentMatch85To94 = GetAnalysisSectionValue(analysisSectionContent, "85%-94%;[0-9]*;(?<PercentMatch85To94>[0-9]*);", "percent match 85 to 94");
            int percentMatch75To84 = GetAnalysisSectionValue(analysisSectionContent, "75%-84%;[0-9]*;(?<PercentMatch75To84>[0-9]*);", "percent match 75 to 84");
            int percentMatch50To74 = GetAnalysisSectionValue(analysisSectionContent, "50%-74%;[0-9]*;(?<PercentMatch50To74>[0-9]*);", "percent match 50 to 74");
            int noMatch = GetAnalysisSectionValue(analysisSectionContent, "Nomatch;[0-9]*;(?<NoMatch>[0-9]*);", "no match");

            return new WordCount(
                repetitions: repetitions,
                contextMatch: contextMatch,
                percentMatch100: percentMatch100,
                percentMatch95To99: percentMatch95To99,
                percentMatch85To94: percentMatch85To94,
                percentMatch75To84: percentMatch75To84,
                percentMatch50To74: percentMatch50To74,
                noMatch: noMatch
            );
        }

        private static int GetAnalysisSectionValue(string analysisSectionContent, string regex, string description) {
            Match match = Regex.Match(analysisSectionContent, regex);
            return !int.TryParse(match.Groups[1].Value, out int result)
                ? throw new WordAnalysisWrongFileException($"Unable to find {description} in analysis section")
                : result;
        }
    }
}
