using System;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategoriesWithArticles
{
    public class GetCategoriesWithArticlesQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Article> Articles {get;set;}

    }
}
