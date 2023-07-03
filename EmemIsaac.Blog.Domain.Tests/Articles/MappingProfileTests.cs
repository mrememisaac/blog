using Xunit;

namespace EmemIsaac.Blog.Application.UnitTests.Articles
{
    public class MappingProfileTests : ArticleTestsBase
    {
        [Fact]
        public void ValidateMappingConfigurationTest()
        {
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}