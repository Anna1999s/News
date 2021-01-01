using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class NewsCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NewsModel> News { get; set; }
        
        public NewsCategory()
        {
            News = new List<NewsModel>();
        }
    }
}
