using EmemIsaac.Blog.Domain.Common;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public string Url { get; private set; }

        public ICollection<Article> Articles { get; set; }

        private Category()
        {

        }

        public Category(string name)
        {
            Name = name;
        }
    }
}
