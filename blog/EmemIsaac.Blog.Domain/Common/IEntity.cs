using System;

namespace EmemIsaac.Blog.Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}