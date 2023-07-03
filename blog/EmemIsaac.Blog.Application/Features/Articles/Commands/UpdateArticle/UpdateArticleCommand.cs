using EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle;
using MediatR;
using System;
using System.Collections.Generic;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest<UpdateArticleCommandResponse>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public ICollection<NewArticleSection> Sections { get; set; }

        public ICollection<ArticleTag> Tags { get; set; }

        public string Stage { get; set; }
    }
}
