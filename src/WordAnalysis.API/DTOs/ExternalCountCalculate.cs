using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WordAnalysis.API.DTOs
{
    public class ExternalCountCalculate
    {
        /// <summary>
        /// URL to download the external file to perform the word count analysis
        /// </summary>
        /// <value>URL to download the external file to perform the word count analysis</value>
        [Required]
        public string FileLink { get; set; }

        /// <summary>
        /// Gets or Sets FileType
        /// </summary>
        [Required]
        public ExternalFileType FileType { get; set; }

        /// <summary>
        /// Gets or Sets SourceLanguage
        /// </summary>
        [Required]
        public string SourceLanguage { get; set; }

        /// <summary>
        /// Gets or Sets CallbackUrl
        /// </summary>
        [Required]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Gets or Sets ServiceRequestId
        /// </summary>
        [Required]
        public string ServiceRequestId { get; set; }
    }
}
