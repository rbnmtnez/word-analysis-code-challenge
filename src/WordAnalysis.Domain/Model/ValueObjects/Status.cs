using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Model.ValueObjects
{
    public enum Status
    {
        Succeeded,
        Failed, 
        DocumentNotFound, 
        FormatNotSupported
    }
}
