
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
}
