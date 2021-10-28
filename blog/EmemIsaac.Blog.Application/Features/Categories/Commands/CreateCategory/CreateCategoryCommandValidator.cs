using FluentValidation;

namespace EmemIsaac.Blog.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private const int NameMaximumLength = 20;
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(NameMaximumLength).WithMessage("{PropertyName} must not exceed {NameMaximumLength} characters.");
        }
    }
}
