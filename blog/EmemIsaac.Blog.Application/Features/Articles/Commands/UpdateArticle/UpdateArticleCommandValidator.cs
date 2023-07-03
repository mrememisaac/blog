using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Entities;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        private readonly IArticleRepository articleRepository;

        public UpdateArticleCommandValidator(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
         
            RuleFor(a => a.Title)
                .NotNull().WithMessage("{0} cannot be null or empty");
            RuleFor(a => a.Title)
                  .MinimumLength(20).WithMessage($"Title must be {Article.MinimumTitleLength} characters or longer");
            RuleFor(a => a.Title)
                .MaximumLength(150).WithMessage($"Title cannot exceed {Article.MaximumTitleLength} characters");

            RuleFor(a => a.ImageUrl)
                .NotNull().WithMessage("{0} cannot be null or empty");
            RuleFor(a => a.Url)
                .NotNull().WithMessage("{0} cannot be null or empty");

            RuleFor(a => a.Description)
                .NotNull().WithMessage("{0} cannot be null or empty");
            RuleFor(a => a.Description)
                .MinimumLength(20).WithMessage($"{0} must be {Article.MinimumDescriptionLength} characters or longer");
            RuleFor(a => a.Description)
                .MaximumLength(150).WithMessage($"{0} cannot exceed {Article.MaximumDescriptionLength} characters");

            RuleFor(a => a.CategoryId)
                .NotNull().WithMessage("{0} cannot be null or empty");

            RuleFor(a => a.Sections)
                .NotNull().WithMessage("Your article must contains at least one section");

            RuleFor(a => a).MustAsync(ArticleMustExist)
                .WithMessage("Cannot update a nonexistent article");
        }

        public async Task<bool> ArticleMustExist(UpdateArticleCommand command, CancellationToken cancellationToken)
        {
            return await articleRepository.Exists(command.Id);
        }
    }
}
