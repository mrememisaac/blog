using EmemIsaac.Blog.Domain.Entities;
using System;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle
{
    public class NewArticleSection
    {
        public Guid ArticleId { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public TitleElement TitleElement { get; set; }
    }
}
