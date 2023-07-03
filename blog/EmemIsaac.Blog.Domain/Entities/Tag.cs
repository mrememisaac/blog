using System;

namespace EmemIsaac.Blog.Domain.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        
        public Guid ArticleId { get; set; }

        public string Name { get; set; }
    }
}
