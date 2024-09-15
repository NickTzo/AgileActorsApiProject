
using API_Aggregation.ApiClient.Interfaces;
using API_Aggregation.Services.IApiServices;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Memory;
using NewsAPI.Models;
using Newtonsoft.Json;

namespace API_Aggregation.Services
{
    /// <summary>
    /// Implements the <see cref="IWeatherApiService"/> interface to provide weather data retrieval services.
    /// </summary>
    public class WeatherApiService : IWeatherApiService
    {
        private readonly IWeatherApiClient _weatherApiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherApiService"/> class.
        /// </summary>
        /// <param name="weatherApiClient">The <see cref="IWeatherApiClient"/> used to interact with the weather API.</param>
        public WeatherApiService(IWeatherApiClient weatherApiClient)
        {
            _weatherApiClient = weatherApiClient;
        }

        /// <summary>
        /// Asynchronously retrieves weather data based on the provided longitude and latitude coordinates.
        /// </summary>
        /// <param name="lon">The longitude coordinate for the weather data retrieval.</param>
        /// <param name="lat">The latitude coordinate for the weather data retrieval.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="string"/> containing the weather data or an error message.</returns>
        public async Task<string> GetWeatherAsync(decimal lon, decimal lat)
        {
            try
            {
                var response = await _weatherApiClient.GetWeatherAsync(lon, lat);
                return response;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}"; // Returns an error message if an exception occurs
            }
        }
    }

}

