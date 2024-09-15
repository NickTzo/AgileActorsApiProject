using API_Aggregation.ApiClient.Interfaces;

namespace API_Aggregation.ApiClient
{
    public class WeatherApiClient : IWeatherApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ApiSettings:WeatherApiKey"] ?? string.Empty;
        }

        /// <summary>
        /// Asynchronously retrieves weather data from an external API based on the provided latitude and longitude coordinates.
        /// </summary>
        /// <param name="lon">The longitude coordinate for the weather data retrieval.</param>
        /// <param name="lat">The latitude coordinate for the weather data retrieval.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="string"/> containing the weather data.</returns>
        /// <remarks>
        /// The method sends a GET request to the weather API using the provided coordinates and API key. It uses the One Call API endpoint to get weather data. If the response is successful, it returns the response content as a string. If the response indicates an error, it throws an exception due to the call to <see cref="HttpResponseMessage.EnsureSuccessStatusCode"/>.
        /// Note: The method includes a commented-out line for an alternative endpoint which should be used if needed.
        /// </remarks>
        public async Task<string> GetWeatherAsync(decimal lon,decimal lat)
        {
            //For exhibition purpose i use the line 20 but if you want to se results you need to use line 19 and comment out line 20
            //var response = await _httpClient.GetAsync($"data/2.5/forecast?id=524901&appid={_apiKey}");
            var response = await _httpClient.GetAsync($"data/3.0/onecall?lat={lat}&lon={lon}&appid={_apiKey}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
