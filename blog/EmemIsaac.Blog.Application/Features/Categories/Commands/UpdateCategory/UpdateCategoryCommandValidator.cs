using FluentValidation;

namespace EmemIsaac.Blog.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {

        private int NameMaximumLength = 20;

        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(NameMaximumLength).WithMessage("{PropertyName} cannot exceed {NameMaximumLength} characters");
        }
    }
}
