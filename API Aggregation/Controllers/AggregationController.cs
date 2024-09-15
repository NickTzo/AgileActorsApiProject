using API_Aggregation.Models;
using API_Aggregation.Services;
using API_Aggregation.Services.IApiServices;
using API_Aggregation.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace API_Aggregation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregationController : ControllerBase
    {
        private readonly IWeatherApiService _weatherService;
        private readonly INewsApiService _newsService;
        private readonly IMoviesApiService _moviesService;


        public AggregationController(INewsApiService newsService, IWeatherApiService weatherService, IMoviesApiService moviesService)
        {
            _newsService = newsService;
            _weatherService = weatherService;
            _moviesService = moviesService;
        }

        /// <summary>
        /// A task that fetch the data for the user through an API
        /// </summary>
        /// <param name="filter">specific filter that the user want to add for the search</param>
        /// <returns>ArticlesResult</returns>
        [HttpPost("News")]
        public async Task<ActionResult<ArticlesResult>> GetNews(NewsFilter filter)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();   
                var result = await _newsService.GetNewsAsync(filter);
                MetricsStore.LogRequest("News", stopwatch.Elapsed.TotalMilliseconds);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves weather information based on the provided longitude and latitude and logs the request performance metrics.
        /// </summary>
        /// <param name="longitude">The longitude coordinate for weather data.</param>
        /// <param name="latitude">The latitude coordinate for weather data.</param>
        /// <returns>Returns an `ActionResult<string>` with the weather information or an error message if an exception occurs.</returns>
        [HttpGet("Weather")]
        public async Task<ActionResult<string>> GetWeather(decimal longigute, decimal latitude)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                var result = await _weatherService.GetWeatherAsync(longigute, latitude);
                stopwatch.Stop();
                MetricsStore.LogRequest("Weather", stopwatch.Elapsed.TotalMilliseconds);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves movies based on the provided movie name and logs the request performance metrics.
        /// </summary>
        /// <param name="movie">The name of the movie to search for.</param>
        /// <returns>Returns an `ActionResult<string>` with the search results or an error message if an exception occurs.</returns>
        [HttpGet("Movies")]
        public async Task<ActionResult<string>> GetMovies(string movie)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                var result = await _moviesService.GetMoviesAsync(movie);
                stopwatch.Stop();
                MetricsStore.LogRequest("Movies", stopwatch.Elapsed.TotalMilliseconds);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///  Retrieves metrics for various APIs, serializes them to a JSON file, and returns them in the response.
        /// </summary>
        /// <returns>Data</returns>
        [HttpGet("Metrics")]
        public IActionResult GetMetrics()
        {
            try
            {
                var allSMetrics = MetricsStore.GetAllStatistics();
                var response = new Dictionary<string, object>();

                foreach (var apiName in allSMetrics.Keys)
                {
                    var stats = allSMetrics[apiName];
                    response[apiName] = new
                    {
                        TotalRequests = stats.TotalRequests,
                        AverageResponseTime = stats.AverageResponseTime,
                        FastRequests = stats.FastRequests,
                        AverageRequests = stats.AverageRequests,
                        SlowRequests = stats.SlowRequests
                    };
                }
                var jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "metrics.json");
                System.IO.File.WriteAllText(filePath, jsonResponse);
                return Ok(response);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
