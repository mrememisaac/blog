using MediatR;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategoriesWithArticles
{
    public class GetCategoriesWithArticlesQuery : IRequest<List<GetCategoriesWithArticlesQueryResponse>>
    {
        public Stage Stage { get; set; }
    }
}
