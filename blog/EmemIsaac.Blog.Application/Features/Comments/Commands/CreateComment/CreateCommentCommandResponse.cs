using EmemIsaac.Blog.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandResponse : BaseResponse
    {
        public CreateCommentModel Comment { get; set; }
        public IEnumerable<string> Errors { get; } = new List<string>();

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

        public CreateCommentCommandResponse(CreateCommentModel model, string message) : base(message)
        {
            Comment = model ?? throw new ArgumentNullException(nameof(model));
        }

        public CreateCommentCommandResponse(IEnumerable<string> errors) :base(errors)
        {
            Errors = errors ?? throw new ArgumentNullException(nameof(errors));
        }
    }
}
