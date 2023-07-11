using MediatR;
using System;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<CreateArticleCommandResponse>
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public Guid CategoryId { get; set; }
    }
}
