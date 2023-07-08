using EmemIsaac.Blog.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandResponse
    {
        public Guid ParentId { get; set; }

        public string Content { get; set; }

        public Guid ArticleId { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

    }
}
