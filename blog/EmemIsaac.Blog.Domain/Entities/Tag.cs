using System;

namespace EmemIsaac.Blog.Domain.Entities
{
    public class Tag
    {
        public static int NameMaximumLength = 50;

        public Guid Id { get; set; }
        
        public Guid ArticleId { get; set; }

        public string Name { get; set; }
    }
}
