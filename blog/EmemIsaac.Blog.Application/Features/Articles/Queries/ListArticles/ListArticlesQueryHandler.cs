using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Articles.Queries.ListArticles
{
    public class ListArticlesQueryHandler : IRequestHandler<ListArticlesQuery, IEnumerable<ListArticlesQueryResponse>>
    {
        private readonly IMapper mapper;
        private readonly ILogger<ListArticlesQueryHandler> logger;
        private readonly IArticleRepository articlesRepository;

        public ListArticlesQueryHandler(IMapper mapper, ILogger<ListArticlesQueryHandler> logger, IArticleRepository articlesRepository)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.articlesRepository = articlesRepository;
        }

        public async Task<IEnumerable<ListArticlesQueryResponse>> Handle(ListArticlesQuery request, CancellationToken cancellationToken)
        {
            request.EnforceLimits();
            var articles = await articlesRepository.GetArticles(request.Page, request.Count);
            return mapper.Map<IEnumerable<ListArticlesQueryResponse>>(articles);
        }
    }
}
