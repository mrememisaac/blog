using EmemIsaac.Blog.Domain.Common;
using System;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Domain.Entities
{

    public class Article : Entity
    {
        public string Title { get; set; }

        public string  ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public DateTimeOffset PublishDate { get; set; }

        public Stage Stage { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
