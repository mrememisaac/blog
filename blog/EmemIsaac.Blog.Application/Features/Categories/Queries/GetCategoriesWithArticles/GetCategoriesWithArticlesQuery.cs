using MediatR;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategoriesWithArticles
{
    public class GetCategoriesWithArticlesQuery : IRequest<List<Category>>
    {
        public Stage Stage { get; set; }
    }
}
