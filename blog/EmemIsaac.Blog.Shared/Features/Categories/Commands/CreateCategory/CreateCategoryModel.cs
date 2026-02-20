using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Shared.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; private set; }

    }
}
