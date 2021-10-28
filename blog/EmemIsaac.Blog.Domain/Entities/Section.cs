using EmemIsaac.Blog.Domain.Common;
using System;

namespace EmemIsaac.Blog.Domain.Entities
{
    public class Section : Entity
    {
        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid ArticleId { get; set; }
    }
}
