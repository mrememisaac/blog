using AutoMapper;
using EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Application.Profiles;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace EmemIsaac.Blog.Application.UnitTests.Articles.Commands
{
    public class CreateArticleTests : ArticleTestsBase
    {
        [Fact]
        public async void Can_Create_Article()
        {
            var command = new CreateArticleCommand
            {
                Title= "This is a sample article heading",
                Description= "This is a sample article Description. This is a sample article Description. This is a sample article Description",
                ImageUrl= "abc.jpg",
                Url= "test",
            };
            var logger = new Mock<ILogger<CreateArticleCommandHandler>>();
            var validator = new CreateArticleCommandValidator();
            var handler = new CreateArticleCommandHandler(mapper, logger.Object, validator, articleRepository);
            
            var collection = await articleRepository.ListAll();
            var count = collection.Count;

            await handler.Handle(command, cancellationToken);

            collection.Count.ShouldBe(count + 1);
        }
    }
}