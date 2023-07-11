using Castle.Core.Logging;
using EmemIsaac.Blog.Application.Features.Articles.Commands.DeleteArticle;
using EmemIsaac.Blog.Application.Features.Categories.Commands.DeleteCategory;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EmemIsaac.Blog.Application.UnitTests.Articles.Commands
{
    public class DeleteArticleTests : ArticleTestsBase
    {
        [Fact]
        public async Task Can_Delete_Article()
        {
            var articles = await articleRepository.ListAll();
            var count = articles.Count;
            var command = new DeleteArticleCommand { ArticleId = articles[0].Id };
            var logger = new Mock<ILogger<DeleteArticleCommandHandler>>();

            var handler = new DeleteArticleCommandHandler(logger.Object, articleRepository);
            handler.Handle(command, cancellationToken);

            articles.Count().ShouldBe(count - 1);
        }
    }
}