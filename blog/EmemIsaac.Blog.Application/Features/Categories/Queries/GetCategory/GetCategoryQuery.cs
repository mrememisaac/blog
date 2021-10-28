using MediatR;
using System;

namespace EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<Category>
    {
        public Guid Id { get; set; }
    }
}
