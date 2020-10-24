using System.ComponentModel.DataAnnotations.Schema;

namespace MEMAnalyzer_Backend.DBModels
{
    public class Mem : BaseEntity
    {
        public string Code { get; set; }

        public string Picture { get; set; }

        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
