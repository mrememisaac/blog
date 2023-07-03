using MediatR;
using System;

namespace EmemIsaac.Blog.Application.Features.Articles.Queries.GetArticleById
{
    public class GetArticleByIdQuery : IRequest<GetArticleQueryResponse>
    {
        public Guid Id { get; set; }

        public bool IncludeSections { get; set; } = true;

        public bool IncludeComments { get; set; } = true;

        public bool IncludeTags { get; set; } = true;
    }
}
