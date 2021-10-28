using EmemIsaac.Blog.Domain.Common;
using System;

namespace EmemIsaac.Blog.Domain.Entities
{
    public class Comment : Entity
    {
        public Guid ParentId { get; set; }

        public string Content { get; set; }

        public Article Article { get; set; }

        public Guid ArticleId { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}
