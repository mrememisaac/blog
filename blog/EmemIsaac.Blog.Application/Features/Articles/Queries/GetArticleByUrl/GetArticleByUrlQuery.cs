using MediatR;
using System;

namespace EmemIsaac.Blog.Application.Features.Articles.Queries.GetArticleByUrl
{
    public class GetArticleByUrlQuery : IRequest<GetArticleQueryResponse>
    {
        public string Url { get; set; }

        public bool IncludeSections { get; set; } = true;

        public bool IncludeComments { get; set; } = true;

        public bool IncludeTags { get; set; } = true;
    }
}
