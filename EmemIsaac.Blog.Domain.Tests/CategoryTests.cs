using EmemIsaac.Blog.Domain.Entities;
using Xunit;

namespace EmemIsaac.Blog.Application.UnitTests
{
    public class CategoryFeatureTests
    {
        [Fact]
        public void Cannot_Create_Nameless_Category()
        {
            Assert.Throws<System.ArgumentException>(() => new Category(" "));
        }
    }
}