using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Infrastructure.Repositories.QueueStorage
{
    public class QueueStorageOptions
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
