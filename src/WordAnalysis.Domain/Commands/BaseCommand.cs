using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Commands
{
    public class BaseCommand<TResult> : ICommand<TResult> where TResult : class
    {
        public DateTime DateTime { get; }
        public Guid Id { get;}

        public BaseCommand()
        {
            DateTime = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }
    }
}
