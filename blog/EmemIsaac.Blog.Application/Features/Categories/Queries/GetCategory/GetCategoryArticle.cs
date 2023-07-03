using System;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryArticle
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public GetCategoryModel Category { get; set; }
    }
}
