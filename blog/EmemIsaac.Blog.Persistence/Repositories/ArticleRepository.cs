using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Persistence.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(BlogDbContext context) : base(context)
        { 
        }

        public async Task<Article> GetArticleByUrl(string url)
        {
            return await context.Articles.FirstOrDefaultAsync(x => x.Url == url);
        }

        public async Task<IReadOnlyList<Article>> GetArticles(int page = 0, int numberOfRecords = 50)
        {
            return await context.Articles.Skip(page*numberOfRecords).Take(numberOfRecords).ToListAsync();
        }
    }
}
