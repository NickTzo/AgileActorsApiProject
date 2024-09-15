namespace API_Aggregation.ApiClient.Interfaces
{
    public interface IMoviesApiClient
    {
        /// <summary>
        /// Asynchronously retrieves movie data based on the provided movie name.
        /// </summary>
        /// <param name="movie">The name of the movie to retrieve data for.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="string"/> containing the movie data.</returns>
        Task<string> GetMoviesAsync(string movie);
    }
}

