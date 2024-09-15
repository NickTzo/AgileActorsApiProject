using NewsAPI.Constants;
using System.Globalization;

namespace API_Aggregation.Models
{
    /// <summary>
    /// Represents a filter for news articles, allowing the specification of default title, 
    /// sorting options, language, and date range for filtering news results.
    /// </summary>
    public class NewsFilter
    {
        /// <summary>
        /// Gets or sets the default title to filter news articles by.
        /// </summary>
        public string? DefaultTitle { get; set; }

        /// <summary>
        /// Gets or sets the default sorting criteria for news articles.
        /// </summary>
        public SortBys? DefaultSortBy { get; set; }

        /// <summary>
        /// Gets or sets the default language for news articles.
        /// </summary>
        public Languages? DefaultLanguage { get; set; }

        /// <summary>
        /// Gets or sets the default start date for filtering news articles.
        /// </summary>
        public DateTime? DefaultFromDate { get; set; }
    }

}
