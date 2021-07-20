using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WordAnalysis.API.DTOs
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExternalFileType
    {
        MemoQ = 0,
        TradosStudio = 1,
        WorldServer = 2
    }
}
