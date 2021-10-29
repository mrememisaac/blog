using EmemIsaac.Blog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByName(string name);
        Task<IReadOnlyCollection<Category>> GetCategoriesWithArticles();
    }
}
