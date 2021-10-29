using System;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategory
{
    public class Article
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }

        public Guid CategoryId { get; set; }

        public GetCategoryModel Category { get; set; }
    }
}
