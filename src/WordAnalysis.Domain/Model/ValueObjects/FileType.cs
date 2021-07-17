using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Model.ValueObjects
{
    public enum FileType
    {
        Succeeded,
        Failed, 
        DocumentNotFound, 
        FormatNotSupported
    }
}
