using System.Collections.Generic;
using System.Threading.Tasks;
using News.Models;

namespace News.Services
{
    public interface INewsService
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
