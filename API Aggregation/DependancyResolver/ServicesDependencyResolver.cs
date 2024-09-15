using API_Aggregation.Services;
using API_Aggregation.Services.IApiServices;

namespace API_Aggregation.NewFolder
{
    /// <summary>
    /// Provides extension methods for registering services with dependency injection
    /// </summary>
    public static class ServicesDependencyResolver
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<INewsApiService, NewsApiService>();
            services.AddScoped<IWeatherApiService,WeatherApiService>(); 
            services.AddScoped<IMoviesApiService, MoviesApiService>();
            return services;
        }
    }
}
