using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Model.Aggregates
{
    public class WordCountAnalysis
    {
        private readonly IList<WordCount> _wordCounts = new List<WordCount>();

        public WordCountAnalysis(IList<WordCount> wordCounts)
        {
            _wordCounts = wordCounts ?? throw new ArgumentNullException(nameof(wordCounts));
        }

        public WordCountAnalysis()
        {
        }

        public void AddWordCount(WordCount wordCount) => _wordCounts.Add(wordCount);

        public WordCount GetSummary()
        {
            return _wordCounts.Aggregate((wordCountAggregate, wordCount) =>
            {
                wordCountAggregate.Repetitions += wordCount.Repetitions;
                wordCountAggregate.ContextMatch += wordCount.ContextMatch;
                wordCountAggregate.PercentMatch100 += wordCount.PercentMatch100;
                wordCountAggregate.PercentMatch95To99 += wordCount.PercentMatch95To99;
                wordCountAggregate.PercentMatch85To94 += wordCount.PercentMatch85To94;
                wordCountAggregate.PercentMatch75To84 += wordCount.PercentMatch75To84;
                wordCountAggregate.PercentMatch50To74 += wordCount.PercentMatch50To74;
                wordCountAggregate.NoMatch += wordCount.NoMatch;

                return wordCountAggregate;
            });
        }

        public IList<WordCount> GetWordCounts() => _wordCounts;

    }
}
