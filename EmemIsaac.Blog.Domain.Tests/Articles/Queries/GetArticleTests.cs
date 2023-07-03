using EmemIsaac.Blog.Application.Features.Articles.Queries.GetArticleById;
using EmemIsaac.Blog.Application.Features.Articles.Queries.GetArticleByUrl;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EmemIsaac.Blog.Application.UnitTests.Articles.Queries
{
    public class GetArticleTests : ArticleTestsBase
    {
        [Fact]
        public async Task Can_Retrieve_Article_By_Id()
        {
            var query = new GetArticleByIdQuery { Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}") };
            var logger = new Mock<ILogger<GetArticleByIdQueryHandler>>().Object;
            var handler = new GetArticleByIdQueryHandler(mapper, articleRepository, logger);

            var article = await handler.Handle(query, cancellationToken);

            article.ShouldNotBeNull();
            article.Id.ShouldBeEquivalentTo(query.Id);
        }

        [Fact]
        public async Task Can_Retrieve_Article_By_Url()
        {
            var query = new GetArticleByUrlQuery { Url = "sample-article" };
            var logger = new Mock<ILogger<GetArticleByUrlQueryHandler>>().Object;
            var handler = new GetArticleByUrlQueryHandler(mapper, articleRepository, logger);

            var article = await handler.Handle(query, cancellationToken);

            article.ShouldNotBeNull();
            article.Url.ShouldBeEquivalentTo(query.Url);
        }
    }
}