using EmemIsaac.Blog.Domain.Entities;
using System;

namespace EmemIsaac.Blog.Application.Features.Articles
{
    public class ArticleSection
    {
        public Guid Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public TitleElement TitleElement { get; set; }
    }
}
