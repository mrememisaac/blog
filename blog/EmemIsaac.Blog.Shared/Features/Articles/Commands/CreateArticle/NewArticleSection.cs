using System;

namespace EmemIsaac.Blog.Shared.Features.Articles.Commands.CreateArticle
{
    public class NewArticleSection
    {
        public Guid ArticleId { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

    }
}
