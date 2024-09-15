using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_Aggregation.ApiClient.Interfaces
{
    public interface IWeatherApiClient
    {
        /// <summary>
        /// Asynchronously retrieves weather data based on the provided longitude and latitude coordinates.
        /// </summary>
        /// <param name="lon">The longitude coordinate for the weather data retrieval.</param>
        /// <param name="lat">The latitude coordinate for the weather data retrieval.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="string"/> containing the weather data.</returns>
        Task<string> GetWeatherAsync(decimal lon,decimal lat);
    }
}
