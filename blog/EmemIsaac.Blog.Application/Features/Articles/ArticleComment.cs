using System;

namespace EmemIsaac.Blog.Application.Features.Articles
{
    public class ArticleComment
    {
        public Guid ParentId { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public DateTimeOffset CreateDate { get; set; }
    }
}
