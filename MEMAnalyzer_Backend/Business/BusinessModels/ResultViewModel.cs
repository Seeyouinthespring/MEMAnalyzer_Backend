
namespace MEMAnalyzer_Backend.Business
{
    /// <summary>
    /// The results of quiz for user
    /// </summary>
    public class ResultViewModel
    {
        /// <summary>
        /// Percentage of domestic
        /// </summary>
        /// <example>12</example>
        public double Domestic { get; set; }

        /// <summary>
        /// Percentage of popular
        /// </summary>
        /// <example>12</example>
        public double Popular { get; set; }

        /// <summary>
        /// Percentage of pointless
        /// </summary>
        /// <example>12</example>
        public double Pointless { get; set; }

        /// <summary>
        /// Percentage of intellectual
        /// </summary>
        /// <example>12</example>
        public double Intellectual { get; set; }

        /// <summary>
        /// Percentage of conservative
        /// </summary>
        /// <example>12</example>
        public double Conservative { get; set; }

        /// <summary>
        /// Statement about user
        /// </summary>
        /// <example>ure r beautiful</example>
        public string Statement { get; set; }
    }
}
