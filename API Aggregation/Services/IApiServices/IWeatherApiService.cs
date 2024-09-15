using NewsAPI.Models;

namespace API_Aggregation.Services.IApiServices
{
    /// <summary>
    /// Defines the contract for a service that retrieves weather data.
    /// </summary>
    public interface IWeatherApiService
    {
        /// <summary>
        /// Asynchronously retrieves weather data based on the provided longitude and latitude coordinates.
        /// </summary>
        /// <param name="lon">The longitude coordinate for the weather data retrieval.</param>
        /// <param name="lat">The latitude coordinate for the weather data retrieval.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="string"/> containing the weather data.</returns>
        Task<string> GetWeatherAsync(decimal lon, decimal lat);
    }

}
