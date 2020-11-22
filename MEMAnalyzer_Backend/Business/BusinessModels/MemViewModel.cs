
using MEMAnalyzer_Backend.DBModels;

namespace MEMAnalyzer_Backend.Business
{
    /// <summary>
    /// Model for memes
    /// </summary>
    public class MemViewModel
    {
        /// <summary>
        /// Id of the mem
        /// </summary>
        /// <example>1</example>
        public long Id { get; set; }

        /// <summary>
        /// Picture code of mem
        /// </summary>
        /// <example>brokendog</example>
        public string Picture { get; set; }
    }

    public class MemDtoModel
    {
        /// <summary>
        /// Id of the category
        /// </summary>
        /// <example>1</example>
        public long CategoryId { get; set; }

        /// <summary>
        /// Picture code of mem
        /// </summary>
        /// <example>brokendog</example>
        public string Code { get; set; }
    }

    public class MemWithCategoryViewModel: MemViewModel
    {
        /// <summary>
        /// CategoryId
        /// </summary>
        /// <example>2</example>
        public string CategoryId { get; set; }

        /// <summary>
        /// Category model
        /// </summary>
        public Category Category { get; set; }
    }
}
