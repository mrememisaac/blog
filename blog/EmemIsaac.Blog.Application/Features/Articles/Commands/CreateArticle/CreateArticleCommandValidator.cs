using EmemIsaac.Blog.Domain.Entities;
using FluentValidation;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
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

            //RuleFor(a => a.Sections).NotNull().WithMessage("Your article must contains at least one section");
        }
    }
}
