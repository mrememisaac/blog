using EmemIsaac.Blog.Application.Features.Categories.Commands.CreateCategory;
using EmemIsaac.Blog.Application.Responses;
using EmemIsaac.Blog.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<CreateArticleCommandResponse>
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public ICollection<NewArticleSection> Sections { get; set; }
    }
}
