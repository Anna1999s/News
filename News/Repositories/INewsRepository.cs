using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Repositories
{
    public interface INewsRepository
    {
        Task<NewsModel> GetNewsAsync(int id);
        Task<IEnumerable<NewsModel>> GetNews(int newsCategoryId);
        Task AddNewsAsync(NewsModel newsModel);
        Task<IEnumerable<NewsModel>> GetNewsAsync();
        Task DeleteNewsAsync(int id);
        Task UpdateNewsAsync(NewsModel newsModel);

        Task<NewsCategory> GetNewsCategoryAsync(int id);
        Task AddNewsCategoryAsync(NewsCategory newsCategory);
        Task<IEnumerable<NewsCategory>> GetNewsCategoryAsync();
        Task DeleteNewsCategoryAsync(int id);
        Task UpdateNewsCategoryAsync(NewsCategory newsCategory);
    }
}
