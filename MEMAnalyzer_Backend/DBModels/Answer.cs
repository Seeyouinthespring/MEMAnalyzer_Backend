using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.DBModels
{
    public class Answer : BaseEntity
    {
        public int Mark { get; set; }

        [ForeignKey(nameof(Mem))]
        public long MemId { get; set; }
        public Mem Mem { get; set; }

        [ForeignKey(nameof(Result))]
        public long ResultId { get; set; }
        public Result Result { get; set; }
    }
}
