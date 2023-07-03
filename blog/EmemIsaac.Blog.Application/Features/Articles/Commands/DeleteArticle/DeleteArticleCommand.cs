using EmemIsaac.Blog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest<BaseResponse>
    {
        public Guid ArticleId { get; set; }
    }
}
