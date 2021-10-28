using MediatR;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {

    }
}
