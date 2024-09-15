using API_Aggregation.ApiClient;
using API_Aggregation.ApiClient.Interfaces;
using System.Runtime.CompilerServices;

namespace API_Aggregation.DependancyResolver
{
    /// <summary>
    /// Provides extension methods for registering HTTP clients with dependency injection
    /// </summary>
    public static class ClientDependencyResolver
    {
        public static IServiceCollection AddClients(this IServiceCollection services)
        {
            services.AddHttpClient<IWeatherApiClient, WeatherApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/");
            });


            services.AddHttpClient<IMoviesApiClient, MoviesApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://movie-database-alternative.p.rapidapi.com/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
