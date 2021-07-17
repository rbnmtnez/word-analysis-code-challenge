using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Infrastructure.Model
{
    public class QueueEntity : IQueueEntity
    {
        public string Type { get; set; }
        public string Data { get; set; }

        public QueueEntity(string type, string data)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

    }
}
