using News.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace News.ViewModels
{
    public class NewsViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }

        public int Id { get; set; }

        [Display(Name = "News Title")]
        //[Required(ErrorMessage = ("News Title is required.")), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string NewsTitle { get; set; }
        public string Content { get; set; }
        public NewsCategory Category { get; set; }
        public IEnumerable<NewsCategory> Categoryes { get; set; }
    }
}