namespace API_Aggregation.Services.IApiServices
{
    /// <summary>
    /// Defines the contract for a service that retrieves movie data.
    /// </summary>
    public interface IMoviesApiService
    {
        /// <summary>
        /// Asynchronously retrieves movie data based on the provided movie name.
        /// </summary>
        /// <param name="movie">The name of the movie to retrieve data for.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="string"/> containing the movie data.</returns>
        Task<string> GetMoviesAsync(string movie);
    }

}
