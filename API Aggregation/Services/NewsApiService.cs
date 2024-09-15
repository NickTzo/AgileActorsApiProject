using NewsAPI.Models;
using NewsAPI;
using NewsAPI.Constants;
using API_Aggregation.Services.IApiServices;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using API_Aggregation.Models;

namespace API_Aggregation.Services
{
    /// <summary>
    /// Implements the <see cref="INewsApiService"/> interface to provide news data retrieval services.
    /// </summary>
    public class NewsApiService : INewsApiService
    {
        private readonly string _apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsApiService"/> class.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> used to retrieve the API key for the news API.</param>
        public NewsApiService(IConfiguration configuration)
        {
            _apiKey = configuration["ApiSettings:NewsApiKey"] ?? string.Empty;
        }

        /// <summary>
        /// Asynchronously retrieves news articles based on the provided filter criteria.
        /// </summary>
        /// <param name="filter">The <see cref="NewsFilter"/> object containing the criteria for filtering news articles.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="ArticlesResult"/> containing the retrieved news articles.</returns>
        public async Task<ArticlesResult> GetNewsAsync(string? DefaultTitle, SortBys? DefaultSortBy, Languages? DefaultLanguage, DateTime? DefaultFromDate)
        {
            try
            {
                var newsApiClient = new NewsApiClient($"{_apiKey}");
                var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
                {
                    Q = DefaultTitle ?? "News",
                    SortBy = DefaultSortBy ?? SortBys.Popularity,
                    Language = DefaultLanguage ?? Languages.EN,
                    From = DefaultFromDate ?? DateTime.Today.AddMonths(-1),
                });
                return articlesResponse;
            }
            catch (Exception)
            {
                return new ArticlesResult(); // Returning an empty ArticlesResult on error
            }
        }
    }

}
