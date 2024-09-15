using API_Aggregation.ApiClient.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.Http;

namespace API_Aggregation.ApiClient
{
    public class MoviesApiClient : IMoviesApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public MoviesApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ApiSettings:MoviesApiKey"] ?? string.Empty;
        }

        /// <summary>
        /// Asynchronously retrieves movie data from an external API based on the provided movie name.
        /// </summary>
        /// <param name="movie">The name of the movie to search for.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="string"/> containing the movie data or an error message.</returns>
        /// <remarks>
        /// The method sets the required headers for the API request, including the API key and host. It sends a GET request to the API endpoint to search for the movie. If the response is successful, the method returns the response content as a string. If the response indicates an error or if an exception occurs during the request, it returns an empty string or an error message, respectively.
        /// </remarks>

        public async Task<string> GetMoviesAsync(string movie)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", $"{_apiKey}");
                _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "moviedatabase8.p.rapidapi.com");
                var response = await _httpClient.GetAsync($"Search/{movie}");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return content;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return $"Error:{ex.Message}";
            }
           
        }
    }
}