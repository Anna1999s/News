using News.Models;
using News.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task AddNewsAsync(NewsModel newsModel)
        {
            await _newsRepository.AddNewsAsync(newsModel);
        }

        public async Task<IEnumerable<NewsModel>> GetNewsAsync()
        {
            return await _newsRepository.GetNewsAsync();
        }

        public async Task<IEnumerable<NewsModel>> GetNews(int newsCategoryId)
        {
            return await _newsRepository.GetNews(newsCategoryId);
        }

        public async Task<NewsModel> GetNewsAsync(int id)
        {
            return await _newsRepository.GetNewsAsync(id);
        }

        public async Task UpdateNewsAsync(NewsModel newsModel)
        {
            await _newsRepository.UpdateNewsAsync(newsModel);
        }

        public async Task DeleteNewsAsync(int id)
        {
            await _newsRepository.DeleteNewsAsync(id);
        }

        public async Task<NewsCategory> GetNewsCategoryAsync(int id)
        {
            return await _newsRepository.GetNewsCategoryAsync(id);
        }

        public async Task AddNewsCategoryAsync(NewsCategory newsCategory)
        {
             await _newsRepository.AddNewsCategoryAsync(newsCategory);
        }

        public async Task<IEnumerable<NewsCategory>> GetNewsCategoryAsync()
        {
            return await _newsRepository.GetNewsCategoryAsync();
        }

        public async Task DeleteNewsCategoryAsync(int id)
        {
            await _newsRepository.DeleteNewsCategoryAsync(id);
        }

        public async Task UpdateNewsCategoryAsync(NewsCategory newsCategory)
        {
             await _newsRepository.UpdateNewsCategoryAsync(newsCategory);
        }
    }
}
