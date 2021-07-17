using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Infrastructure.Model
{
    public interface IQueueEntity
    {
        public string Type { get; set; }
        public string Data { get; set; }
    }
}
