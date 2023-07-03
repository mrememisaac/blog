using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EmemIsaac.Blog.Application.Features.Articles.Queries.ListArticles
{

    public class ListArticlesQuery : IRequest<IEnumerable<ListArticlesQueryResponse>>
    {
        public int Count { get; set; } = 20;

        public int Page { get; set; } = 0;

        public void EnforceLimits()
        {
            Count = Count < 0 ? 20 : Count;
            Count = Count > 100 ? 100 : Count;
            Page = Page < 0 ? 0 : Page;
            Page = Page > 1000 ? 0 : Page;
        }
    }
}
