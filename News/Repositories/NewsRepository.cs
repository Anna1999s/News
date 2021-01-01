using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace News.Repositories
{
    public class NewsRepository : INewsRepository
    {
        public NewsRepository()
        {

        }

        static DbContextOptions<ApplicationDbContext> GetOptions()
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            return options;
        }

        ApplicationDbContext newsContext = new ApplicationDbContext(GetOptions());
        public async Task<NewsModel> GetNewsAsync(int id)
        {
            return await newsContext.News.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddNewsAsync(NewsModel newsModel)
        {
            newsContext.News.Add(newsModel);

            await newsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsModel>> GetNewsAsync()
        {
            return await newsContext.News.Include(c => c.Category).OrderByDescending(p => p.Id).Take(6).ToListAsync();  //Include(c=>c.Category).ToListAsync();
        }

        public async Task<IEnumerable<NewsModel>> GetNews(int newsCategoryId)
        {
            return await newsContext.News.Include(p => p.Category).Where(p => p.CategoryId == newsCategoryId).ToListAsync();
        }

        public async Task DeleteNewsAsync(int id)
        {
            var news = await newsContext.News.FirstOrDefaultAsync(f => f.Id == id);

            newsContext.Entry(news).State = EntityState.Deleted;

            await newsContext.SaveChangesAsync();
        }

        public async Task UpdateNewsAsync(NewsModel newsModel)
        {
            newsContext.Entry(newsModel).State = EntityState.Modified;

            await newsContext.SaveChangesAsync();
        }

        public async Task<NewsCategory> GetNewsCategoryAsync(int id)
        {
            return await newsContext.NewsCategory.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddNewsCategoryAsync(NewsCategory newsCategory)
        {
            newsContext.NewsCategory.Add(newsCategory);

            await newsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsCategory>> GetNewsCategoryAsync()
        {
            return await newsContext.NewsCategory.ToListAsync();
        }

        public async Task DeleteNewsCategoryAsync(int id)
        {
            var newsCategory = await newsContext.NewsCategory.FirstOrDefaultAsync(f => f.Id == id);

            newsContext.Entry(newsCategory).State = EntityState.Deleted;

            await newsContext.SaveChangesAsync();
        }

        public async Task UpdateNewsCategoryAsync(NewsCategory newsCategory)
        {
            newsContext.Entry(newsCategory).State = EntityState.Modified;

            await newsContext.SaveChangesAsync();
        }

    }
}
