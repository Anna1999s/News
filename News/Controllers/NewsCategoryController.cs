using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.Models;
using News.Services;

namespace News.Controllers
{
    public class NewsCategoryController : Controller
    {
        private readonly INewsService _newsService;

        public NewsCategoryController(INewsService newsService)
        {
            _newsService = newsService;
        }
        public async Task<IActionResult> Index()
        {
            var newsCategory = await _newsService.GetNewsCategoryAsync();

            return View(newsCategory);
        }

        public IActionResult AddNewsCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddANewsCategory(NewsCategory newsCategory, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(newsCategory);
            }

            await _newsService.AddNewsCategoryAsync(newsCategory);

            return RedirectToLocal(redirectUrl);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewsCategory(NewsCategory newsCategory, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(newsCategory);
            }

            await _newsService.UpdateNewsCategoryAsync(newsCategory);

            return RedirectToLocal(redirectUrl);
        }

        public async Task<IActionResult> EditNewsCategory(int id)
        {
            var newsCategory = await _newsService.GetNewsCategoryAsync(id);

            return View(newsCategory);
        }

        public async Task<IActionResult> DeleteNewsCategory(int id)
        {
            await _newsService.DeleteNewsCategoryAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetNews(int id)
        {
            var news = await _newsService.GetNews(id);

            return View(news);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "NewsCategory");
        }
    }
}