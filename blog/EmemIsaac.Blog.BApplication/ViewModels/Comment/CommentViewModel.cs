namespace EmemIsaac.Blog.BApplication.ViewModels.Comment
{
    public class CommentViewModel
    {
        public Guid ParentId { get; set; }

        public string Content { get; set; }

        public Guid ArticleId { get; set; }

        public string AuthorName { get; set; }
    }
}
