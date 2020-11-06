using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Business
{
    /// <summary>
    /// Model to send user`s answers for analyzation
    /// </summary>
    public class ResultToHandleModel
    {
        /// <summary>
        /// Id of the mem
        /// </summary>
        /// <example>12</example>
        [Required]
        public long? MemId { get; set; }

        /// <summary>
        /// Users mark for the mem
        /// </summary>
        /// <example>1</example>
        [Required]
        [Range(1,5)]
        public int Mark { get; set; }
    }
}
