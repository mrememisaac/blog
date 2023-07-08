using MediatR;
using System;

namespace EmemIsaac.Blog.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<CreateCommentCommandResponse>
    {
        public Guid ParentId { get; set; }

        public string Content { get; set; }

        public Guid ArticleId { get; set; }

        public string AuthorId { get; set; }
        
        public string AuthorName { get; set; }
    }
}
