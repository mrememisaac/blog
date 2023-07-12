using EmemIsaac.Blog.BApplication.ViewModels.Comment;

namespace EmemIsaac.Blog.BApplication.ViewModels.Articles
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public string AuthorName { get; set; }

        public string Stage { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }
    }
}
