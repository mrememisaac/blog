using MediatR;
using System;

namespace EmemIsaac.Blog.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryModel>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
