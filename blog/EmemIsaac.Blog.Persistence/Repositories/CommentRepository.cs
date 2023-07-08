using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Persistence.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<Comment> GetByContentAuthorAndArticle(string content, string authorId, Guid articleId)
        {
            return await context.Comments.FirstOrDefaultAsync(c => c.Content.Equals(content, StringComparison.InvariantCultureIgnoreCase) && c.CreatorId == authorId && c.ArticleId == articleId);
        }
    }
}
