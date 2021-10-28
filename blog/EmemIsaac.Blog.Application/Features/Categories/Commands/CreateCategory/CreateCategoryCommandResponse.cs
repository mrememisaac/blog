using EmemIsaac.Blog.Application.Responses;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {

        public CreateCategoryCommandResponse() :base()
        {

        }

        public CreateCategoryCommandResponse(IEnumerable<string> errors) : base(errors)
        { }
        
        public CreateCategoryCommandResponse(CreateCategoryModel category) : base()
        {
            Category = category;
        }

        public CreateCategoryModel Category { get; private set; }
    }
}
