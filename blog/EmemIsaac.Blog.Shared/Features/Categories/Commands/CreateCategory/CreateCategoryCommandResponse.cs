using System.Collections.Generic;

namespace EmemIsaac.Blog.Shared.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; private set; }
    }
}
