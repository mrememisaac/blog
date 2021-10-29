using FluentValidation;
using System;

namespace EmemIsaac.Blog.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        private const int DefaultMaximumLength = 50;
        private const int CommentMaximumLength = 500;

        public CreateCommentCommandValidator()
        {
            RuleFor(p => p.ArticleId)
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} required")
                .NotNull().WithMessage("{PropertyName} required");
            RuleFor(p => p.AuthorId)
                .MaximumLength(DefaultMaximumLength).WithMessage("{PropertyName} cannot exceed {DefaultMaximumStringLength}")
                .NotEmpty().WithMessage("{PropertyName} required")
                .NotNull().WithMessage("{PropertyName} required");
            RuleFor(p => p.AuthorName)
                .MaximumLength(DefaultMaximumLength).WithMessage("{PropertyName} cannot exceed {DefaultMaximumStringLength}")
                .NotEmpty().WithMessage("{PropertyName} required")
                .NotNull().WithMessage("{PropertyName} required");
            RuleFor(p => p.Content)
                .MaximumLength(CommentMaximumLength).WithMessage("{PropertyName} cannot exceed {CommentMaximumLength}")
                .NotEmpty().WithMessage("{PropertyName} required")
                .NotNull().WithMessage("{PropertyName} required");
        }
    }
}
