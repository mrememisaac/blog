using EmemIsaac.Blog.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandResponse : BaseResponse
    {
        public CreateCommentModel Comment { get; set; }

        public CreateCommentCommandResponse() : base()
        {
        }

        public CreateCommentCommandResponse(ValidationResult result) : base(result)
        {

        }

        public CreateCommentCommandResponse(CreateCommentModel model) : base()
        {
            Comment = model ?? throw new ArgumentNullException(nameof(model));
        }

        public CreateCommentCommandResponse(CreateCommentModel model, string message)
        {
            Comment = model ?? throw new ArgumentNullException(nameof(model));
        }

        public CreateCommentCommandResponse(List<string> errors) :base(errors)
        {
            ValidationErrors = errors ?? throw new ArgumentNullException(nameof(errors));
        }
    }
}
