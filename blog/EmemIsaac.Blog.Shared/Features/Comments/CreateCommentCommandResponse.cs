namespace EmemIsaac.Blog.Shared.Features.Comments
{
    public class CreateCommentCommandResponse
    {
        public Guid ParentId { get; set; }

        public string Content { get; set; }

        public Guid ArticleId { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

    }
}
