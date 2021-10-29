using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext context) : base(context)
        { }

        public async Task<Category> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }
            name = name.ToLower();
            return await context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == name);
        }

        public async Task<IReadOnlyCollection<Category>> GetCategoriesWithArticles()
        {
            return await context.Categories.Include(c => c.Articles).ToListAsync();
        }
    }
}
