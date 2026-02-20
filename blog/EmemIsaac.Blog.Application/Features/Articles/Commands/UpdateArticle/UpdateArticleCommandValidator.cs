using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        private readonly IServiceProvider _serviceProvider;

        public UpdateArticleCommandValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RuleFor(a => a.Title)
                .NotNull().WithMessage("{0} cannot be null or empty");
            RuleFor(a => a.Title)
                  .MinimumLength(Article.MinimumTitleLength).WithMessage($"Title must be {Article.MinimumTitleLength} characters or longer");
            RuleFor(a => a.Title)
                .MaximumLength(Article.MaximumTitleLength).WithMessage($"Title cannot exceed {Article.MaximumTitleLength} characters");

            RuleFor(a => a.ImageUrl)
                .NotNull().WithMessage("{0} cannot be null or empty");
            RuleFor(a => a.Url)
                .NotNull().WithMessage("{0} cannot be null or empty");

            RuleFor(a => a.Description)
                .NotNull().WithMessage("{0} cannot be null or empty");
            RuleFor(a => a.Description)
                .MinimumLength(Article.MinimumDescriptionLength).WithMessage($"{0} must be {Article.MinimumDescriptionLength} characters or longer");
            RuleFor(a => a.Description)
                .MaximumLength(Article.MaximumDescriptionLength).WithMessage($"{0} cannot exceed {Article.MaximumDescriptionLength} characters");

            RuleFor(a => a.CategoryId)
                .NotNull().WithMessage("{0} cannot be null or empty");

            RuleFor(a => a.Content)
                .NotNull().WithMessage("Your article must have some content");
            RuleFor(a => a.Content)
                .MinimumLength(Article.MinimumContentLength).WithMessage($"{0} must be {Article.MinimumContentLength} characters or longer");

            RuleFor(a => a).MustAsync(ArticleMustExist)
                .WithMessage("Cannot update a nonexistent article");

        }

        public async Task<bool> ArticleMustExist(UpdateArticleCommand command, CancellationToken cancellationToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var articleRepository = scope.ServiceProvider.GetRequiredService<IArticleRepository>();
                return await articleRepository.Exists(command.Id);
            }
        }
    }
}