using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly BlogDbContext context;

        public Repository(BlogDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
