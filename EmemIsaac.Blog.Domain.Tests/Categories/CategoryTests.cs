using EmemIsaac.Blog.Domain.Entities;
using Shouldly;
using System.Linq;
using System.Text;
using Xunit;

namespace EmemIsaac.Blog.Application.UnitTests.Categories
{
    public class CategoryFeatureTests
    {
        [Fact]
        public void Cannot_Create_Nameless_Category()
        {
            var exception = Assert.Throws<System.ArgumentException>(() => new Category(" "));
            exception.Message.ShouldContain("cannot be null, empty or whitespace");
        }

        [Fact]
        public void Category_Name_Cannot_Exceed_Maximum()
        {
            var maximum = Category.MaximumCategoryNameLength;
            var name = new string(Enumerable.Repeat('A', maximum + 1).ToArray());
            var exception = Assert.Throws<System.ArgumentException>(() => new Category(name));
            exception.Message.ShouldContain("cannot be longer than");
        }
    }
}