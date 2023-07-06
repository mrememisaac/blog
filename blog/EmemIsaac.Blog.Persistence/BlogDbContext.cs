using EmemIsaac.Blog.Application.Contracts;
using EmemIsaac.Blog.Domain.Common;
using EmemIsaac.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Persistence
{
    public class BlogDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions) : base(dbContextOptions)
        { }

        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions, ILoggedInUserService loggedInUserService) : base(dbContextOptions)
        {
            this._loggedInUserService = loggedInUserService;
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTimeOffset.Now;
                        entry.Entity.ModifierId = _loggedInUserService.UserId;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTimeOffset.Now;
                        entry.Entity.CreatorId = _loggedInUserService.UserId;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
