using EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Application.Features.Articles.Commands.UpdateArticle;
using EmemIsaac.Blog.Application.Features.Articles.Commands.UpdateArticle;
using EmemIsaac.Blog.Application.Features.Categories.Queries.GetCategoriesWithArticles;
using EmemIsaac.Blog.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EmemIsaac.Blog.Application.UnitTests.Articles.Commands
{
    public class UpdateArticleTests : ArticleTestsBase
    {
        [Fact]
        public async void Can_Update_Article()
        {
            var repo = articleRepository;
            var collection = await repo.ListAll();
            var article = collection.First();

            var command = new UpdateArticleCommand
            {
                Id = article.Id,
                Title = article.Title + " updated",
                Description = article.Description + " updated",
                ImageUrl = article.ImageUrl,
                Url = article.Url + "-updated",   
                Content = article.Content + "-updated"
            };
            var logger = new Mock<ILogger<UpdateArticleCommandHandler>>().Object;
            var validator = new UpdateArticleCommandValidator(_serviceProvider);
            var handler = new UpdateArticleCommandHandler(mapper, logger, validator, repo);


            await handler.Handle(command, cancellationToken);

            var updatedArticle = await repo.GetById(command.Id);
            updatedArticle.Title.ShouldBe(command.Title);
            updatedArticle.Description.ShouldBe(command.Description);
        }
    }
}