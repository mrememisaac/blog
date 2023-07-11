using EmemIsaac.Blog.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace EmemIsaac.Blog.Persistence.IntegrationTests
{
    public class BlogDbContextTests
    {
        private readonly BlogDbContext _context;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;


        public BlogDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<BlogDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _context = new BlogDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async Task On_Create_CreateDate_Property_Is_Set()
        {
            var category = new EmemIsaac.Blog.Domain.Entities.Category("Test Category");
            category = _context.Categories.Add(category).Entity;
            await _context.SaveChangesAsync();
            category.CreateDate.ShouldBeInRange(DateTimeOffset.Now.AddSeconds(-1), DateTimeOffset.Now.AddSeconds(1));
        }

        [Fact]
        public async Task On_Create_CreatedBy_Property_Is_Set()
        {
            var category = new EmemIsaac.Blog.Domain.Entities.Category("Test Category");
            category = _context.Categories.Add(category).Entity;
            await _context.SaveChangesAsync();
            category.CreatorId.ShouldBe(_loggedInUserId);
        }

        [Fact]
        public async Task On_Update_LastModifiedBy_Property_Is_Set()
        {
            var category = new EmemIsaac.Blog.Domain.Entities.Category("Test Category");
            category = _context.Categories.Add(category).Entity; 
            await _context.SaveChangesAsync();
            category.Name = "Test Category Update";
            category = _context.Categories.Update(category).Entity;
            await _context.SaveChangesAsync();
            category.ModifierId.ShouldBe(_loggedInUserId);
        }

        [Fact]
        public async Task On_Update_LastModifiedDate_Property_Is_Set()
        {
            var category = new EmemIsaac.Blog.Domain.Entities.Category("Test Category");
            category = _context.Categories.Add(category).Entity;
            await _context.SaveChangesAsync();
            category.Name = "Test Category Update";
            category = _context.Categories.Update(category).Entity;
            await _context.SaveChangesAsync();
            category.LastModifiedDate.ShouldBeInRange(DateTimeOffset.Now.AddSeconds(-1), DateTimeOffset.Now.AddSeconds(1));
        }
    }
}