namespace API_Aggregation.Models
{
    /// <summary>
    /// Represents metrics related to API performance, including total requests, response times, 
    /// and categorized request speeds (fast, average, slow).
    /// </summary>
    public class ApiMetrics
    {
        /// <summary>
        /// Gets or sets the total number of API requests.
        /// </summary>
        public int TotalRequests { get; set; }

        /// <summary>
        /// Gets or sets the total response time for all API requests.
        /// </summary>
        public double TotalResponseTime { get; set; }

        /// <summary>
        /// Gets or sets the list of individual response times for API requests.
        /// </summary>
        public List<double> ResponseTimes { get; set; } = new List<double>();

        /// <summary>
        /// Gets the average response time, calculated by dividing total response time by total requests.
        /// </summary>
        public double AverageResponseTime => TotalRequests > 0 ? TotalResponseTime / TotalRequests : 0;

        /// <summary>
        /// Gets the number of fast requests, defined as those with response times less than 80% of the average.
        /// </summary>
        public int FastRequests => ResponseTimes.Count(rt => rt < AverageResponseTime * 0.8);

        /// <summary>
        /// Gets the number of average requests, defined as those with response times between 80% and 120% of the average.
        /// </summary>
        public int AverageRequests => ResponseTimes.Count(rt => rt >= AverageResponseTime * 0.8 && rt <= AverageResponseTime * 1.2);

        /// <summary>
        /// Gets the number of slow requests, defined as those with response times greater than 120% of the average.
        /// </summary>
        public int SlowRequests => ResponseTimes.Count(rt => rt > AverageResponseTime * 1.2);
    }

}
