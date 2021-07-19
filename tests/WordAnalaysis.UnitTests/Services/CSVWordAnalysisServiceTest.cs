using FluentAssertions;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using WordAnalysis.Application.Services;
using Xunit;

namespace WordAnalaysis.UnitTests.Services
{
    public class CSVWordAnalysisServiceTest
    {
        [Fact]
        public async Task CSWordAnalysisFileWithOneAnalysisResultTest()
        {
            byte[] fileContent = GetEmbeddedFileContent("Resources.ExtWA_MemoQ_1Section.csv");

            CSVWordAnalysisService csvWordAnalyser = new(fileContent);
            var result = csvWordAnalyser.GetWordCountAnalysis().GetSummary();

            result.Repetitions.Should().Be(16);
            result.ContextMatch.Should().Be(170);
            result.PercentMatch100.Should().Be(2);
            result.PercentMatch95To99.Should().Be(0);
            result.PercentMatch85To94.Should().Be(0);
            result.PercentMatch75To84.Should().Be(13);
            result.PercentMatch50To74.Should().Be(23);
            result.NoMatch.Should().Be(29);

            result.Total.Should().Be(253);
        }

        [Fact]
        public void CSWordAnalysisFileManyAnalysisResultsTest()
        {
            byte[] fileContent = GetEmbeddedFileContent("Resources.ExtWA_MemoQ_3Sections.csv");

            CSVWordAnalysisService csvWordAnalyser = new(fileContent);
            var result = csvWordAnalyser.GetWordCountAnalysis().GetSummary();

            result.Repetitions.Should().Be(5);
            result.ContextMatch.Should().Be(213 + 138 + 273);
            result.PercentMatch100.Should().Be(0);
            result.PercentMatch95To99.Should().Be(0);
            result.PercentMatch85To94.Should().Be(0);
            result.PercentMatch75To84.Should().Be(30 + 7 + 34);
            result.PercentMatch50To74.Should().Be(58 + 6 + 50);
            result.NoMatch.Should().Be(101 + 7 + 50);

            result.Total.Should().Be(407 + 158 + 407);
        }

        private byte[] GetEmbeddedFileContent(string filePath) {
            var assembly = Assembly.GetExecutingAssembly();
            var fullPath = $"{assembly.FullName.Split(',')[0]}.{filePath}";

            Stream resourceStream = assembly.GetManifestResourceStream(fullPath);
            using(MemoryStream ms = new MemoryStream())
            {
                resourceStream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
