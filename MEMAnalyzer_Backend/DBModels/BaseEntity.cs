using System.ComponentModel.DataAnnotations;

namespace MEMAnalyzer_Backend.DBModels
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
