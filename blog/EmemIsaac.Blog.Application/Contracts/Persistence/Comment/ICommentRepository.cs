using EmemIsaac.Blog.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Contracts.Persistence
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment> GetByContentAuthorAndArticle(string content, string authorId, Guid articleId);
    }
}
