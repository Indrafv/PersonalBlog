namespace PersonalBlog.Models
{
    public class Articles
    {
        public int ArticleId { get; set; }
        public DateTime PublishingDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
