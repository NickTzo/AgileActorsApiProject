using API_Aggregation.Models;
using System.Collections.Concurrent;

namespace API_Aggregation.Store
{
    /// <summary>
    /// Provides a thread-safe store for API metrics, allowing logging of requests and retrieval of statistics.
    /// </summary>
    public class MetricsStore
    {
        private static readonly ConcurrentDictionary<string, ApiMetrics> _apiMetriics = new();

        /// <summary>
        /// Logs a request for a specified API, recording its response time and updating the metrics.
        /// </summary>
        /// <param name="apiName">The name of the API being logged.</param>
        /// <param name="responseTime">The response time of the API request.</param>
        public static void LogRequest(string apiName, double responseTime)
        {
            var metrics = _apiMetriics.GetOrAdd(apiName, new ApiMetrics());
            metrics.TotalRequests++;
            metrics.TotalResponseTime += responseTime;
            metrics.ResponseTimes.Add(responseTime);
        }

        /// <summary>
        /// Retrieves the metrics statistics for a specified API.
        /// </summary>
        /// <param name="apiName">The name of the API whose statistics are to be retrieved.</param>
        /// <returns>The <see cref="ApiMetrics"/> object containing the statistics for the specified API.</returns>
        public static ApiMetrics GetStatistics(string apiName)
        {
            _apiMetriics.TryGetValue(apiName, out var statistics);
            return statistics;
        }

        /// <summary>
        /// Retrieves the metrics statistics for all APIs.
        /// </summary>
        /// <returns>A dictionary where the key is the API name and the value is the <see cref="ApiMetrics"/> object for that API.</returns>
        public static Dictionary<string, ApiMetrics> GetAllStatistics()
        {
            return new Dictionary<string, ApiMetrics>(_apiMetriics);
        }
    }
}

