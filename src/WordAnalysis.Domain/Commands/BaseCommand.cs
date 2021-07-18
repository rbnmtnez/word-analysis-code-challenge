using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Commands
{
    public class BaseCommand<TResult> : ICommand<TResult> where TResult : class
    {
        public Guid Id { get;}
        public DateTime DateTime { get; }
        public string Type { get; }

        public BaseCommand()
        {
            Type = this.GetType().Name;
            Id = Guid.NewGuid();
            DateTime = DateTime.UtcNow;
        }
    }
}
