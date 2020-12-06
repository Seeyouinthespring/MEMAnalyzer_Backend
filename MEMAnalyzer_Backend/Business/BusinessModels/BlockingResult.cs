using MEMAnalyzer_Backend.Helpers;
using MEMAnalyzer_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Business.BusinessModels
{
    public class BlockingResult
    {
        /// <summary>
        /// Date when user will be unlocked
        /// </summary>
        /// <example>12.12.2020</example>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Status of blocking
        /// </summary>
        /// <example>Success</example>
        public string Status { get; set; }
    }
}
