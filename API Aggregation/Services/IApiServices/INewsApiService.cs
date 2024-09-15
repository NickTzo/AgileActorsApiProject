using API_Aggregation.Models;
using NewsAPI.Models;

namespace API_Aggregation.Services.IApiServices
{
    /// <summary>
    /// Defines the contract for a service that retrieves news articles.
    /// </summary>
    public interface INewsApiService
    {
        /// <summary>
        /// Asynchronously retrieves news articles based on the provided filter criteria.
        /// </summary>
        /// <param name="filter">The <see cref="NewsFilter"/> object containing the criteria for filtering news articles.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with a result of type <see cref="ArticlesResult"/> containing the retrieved news articles.</returns>
        Task<ArticlesResult> GetNewsAsync(NewsFilter filter);
    }

}
