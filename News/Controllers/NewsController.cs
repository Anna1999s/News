using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.Models;
using News.Services;
using News.ViewModels;

namespace News.Controllers
{
    public class NewsController : Controller
    {

        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetNewsAsync();

            return View(news);
        }

        //public IActionResult GetNews(int newsCategoryId)
        //{
        //    var news = _newsService.GetNews(newsCategoryId);

        //    return View(news);
        //}

        public async Task<IActionResult> AddNews()
        {
            var newsViewModel = new NewsViewModel
            {
                Title = "Add News",
                AddButtonTitle = "Add",
                RedirectUrl = Url.Action("Index", "News"),
                Categoryes = await _newsService.GetNewsCategoryAsync()
            };

            return View(newsViewModel);
        }

        public async Task<IActionResult> DetailsOfNews(int id)
        {
            var news = await _newsService.GetNewsAsync(id);

            return View(new NewsViewModel { Id = news.Id, NewsTitle = news.NewsTitle, Content = news.Content });
        }

        [HttpPost]
        public async Task<IActionResult> SaveNews(NewsViewModel newsViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(newsViewModel);
            }

            var news = await _newsService.GetNewsAsync(newsViewModel.Id);
            if (news != null)
            {
                news.NewsTitle = newsViewModel.NewsTitle;
                news.Content = newsViewModel.Content;

                await _newsService.UpdateNewsAsync(news);
            }

            return RedirectToLocal(redirectUrl);
        }

        public async Task<IActionResult> EditNews(int id)
        {
            var news = await _newsService.GetNewsAsync(id);

            var newsViewModel = new NewsViewModel
            {
                Title = "Edit News",
                AddButtonTitle = "Save",
                RedirectUrl = Url.Action("Index", "News"),
                NewsTitle = news.NewsTitle,
                Id = news.Id,
                Content = news.Content
            };

            return View(newsViewModel);
        }

        public async Task<IActionResult> DeleteNews(int id)
        {
            await _newsService.DeleteNewsAsync(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddANews(NewsViewModel newsViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(newsViewModel);
            }

            var news = new NewsModel
            {
                NewsTitle = newsViewModel.NewsTitle,
                Content = newsViewModel.Content,
                Category = await _newsService.GetNewsCategoryAsync(newsViewModel.Category.Id)
            };

            await _newsService.AddNewsAsync(news);

            return RedirectToLocal(redirectUrl);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "News");
        }
    }
}