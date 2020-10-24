using System.Collections.Generic;

namespace MEMAnalyzer_Backend.DBModels
{
    public class Category : BaseEntity
    {
        public string Code { get; set; }

        public string OfficialCode { get; set; }

        public int Order { get; set; }

        public ICollection<Mem> Memes { get; set; }
    }
}
