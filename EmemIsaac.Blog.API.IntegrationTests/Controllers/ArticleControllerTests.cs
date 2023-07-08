using Castle.Core.Logging;
using EmemIsaac.Blog.Api;
using EmemIsaac.Blog.API.IntegrationTests.Base;
using EmemIsaac.Blog.Application.Features.Articles.Queries.ListArticles;
using System.Text.Json;

namespace EmemIsaac.Blog.API.IntegrationTests.Controllers
{
    public class ArticleControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public ArticleControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Get_All_Articles_Returns_OK()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("articles/all");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<ListArticlesQuery>>(responseString);
            Assert.NotEmpty(result);
            Assert.IsType<List<ListArticlesQuery>>(result);
        }
    }
}