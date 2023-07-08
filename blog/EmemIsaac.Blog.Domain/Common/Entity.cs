using System;

namespace EmemIsaac.Blog.Domain.Common
{
    public class Entity : IEntity
    {
        public const int MaximumUserIdLength = 50;

        public Guid Id { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public string CreatorId { get; set; }

        public DateTimeOffset LastModifiedDate { get; set; }

        public string ModifierId { get; set; }
    }
}
