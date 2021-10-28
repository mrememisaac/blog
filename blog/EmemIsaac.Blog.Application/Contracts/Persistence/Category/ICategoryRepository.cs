using EmemIsaac.Blog.Domain.Entities;

namespace EmemIsaac.Blog.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByName(string name);
    }
}
