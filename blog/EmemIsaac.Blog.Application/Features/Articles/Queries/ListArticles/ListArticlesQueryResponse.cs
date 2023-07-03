using System;

namespace EmemIsaac.Blog.Application.Features.Articles.Queries.ListArticles
{
    public class ListArticlesQueryResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public string AuthorName { get; set; }

        public string Stage { get; set; }
    }
}
