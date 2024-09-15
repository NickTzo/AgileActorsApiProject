using API_Aggregation.ApiClient;
using API_Aggregation.ApiClient.Interfaces;
using API_Aggregation.Services.IApiServices;

namespace API_Aggregation.Services
{
    /// <summary>
    /// Implements the <see cref="IMoviesApiService"/> interface to provide movie data retrieval services.
    /// </summary>
    public class MoviesApiService : IMoviesApiService
    {
        private readonly IMoviesApiClient _moviesApiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesApiService"/> class.
        /// </summary>
        /// <param name="moviesApiClient">The <see cref="IMoviesApiClient"/> used to interact with the movie API.</param>
        public MoviesApiService(IMoviesApiClient moviesApiClient)
        {
            _moviesApiClient = moviesApiClient;
        }

        /// <summary>
        /// Asynchronously retrieves movie data based on the provided movie name.
        /// </summary>
        /// <param name="movie">The name of the movie to retrieve data for.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="string"/> containing the movie data.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while retrieving the movie data.</exception>
        public async Task<string> GetMoviesAsync(string movie)
        {
            try
            {
                var response = await _moviesApiClient.GetMoviesAsync(movie);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}