using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.DBModels
{
    public class Statement : BaseEntity
    {
        public string OfficialCode { get; set; }

        public string Text { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
