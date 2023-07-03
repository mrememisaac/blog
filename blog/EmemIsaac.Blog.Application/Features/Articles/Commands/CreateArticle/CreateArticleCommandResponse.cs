using System;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public ICollection<ArticleSection> Sections { get; set; } = new List<ArticleSection>();

        public DateTimeOffset CreateDate { get; set; }

        public string CreatorId { get; set; }

        public string Stage { get; set; }

    }
}
