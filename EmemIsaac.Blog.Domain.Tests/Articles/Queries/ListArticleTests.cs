using EmemIsaac.Blog.Application.Features.Articles.Queries.ListArticles;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EmemIsaac.Blog.Application.UnitTests.Articles.Queries
{
    public class ListArticleTests : ArticleTestsBase
    {
        [Fact]
        public async Task Can_List_Articles()
        {
            var request = new ListArticlesQuery { Count = 1};
            var logger = new Mock<ILogger<ListArticlesQueryHandler>>().Object;
            var handler = new ListArticlesQueryHandler(mapper, logger, articleRepository);

            var articles = await handler.Handle(request, cancellationToken);

            articles.Count().ShouldBe(1);
        }
    }
}