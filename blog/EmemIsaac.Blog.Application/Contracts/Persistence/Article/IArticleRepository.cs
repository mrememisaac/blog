using EmemIsaac.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Contracts.Persistence
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<Article> GetArticleByUrl(string url);

        Task<IReadOnlyList<Article>> GetArticles(int page = 1, int numberOfRecords = 50);
    }
}
