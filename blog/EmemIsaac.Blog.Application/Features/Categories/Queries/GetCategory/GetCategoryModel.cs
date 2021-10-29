using System;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Article> Articles { get; set; }
    }
}
