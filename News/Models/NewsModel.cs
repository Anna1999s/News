namespace News.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string NewsTitle { get; set; }
        public string Content { get; set; }
        public int? CategoryId { get; set; }
        public NewsCategory Category { get; set; }
    }
}
