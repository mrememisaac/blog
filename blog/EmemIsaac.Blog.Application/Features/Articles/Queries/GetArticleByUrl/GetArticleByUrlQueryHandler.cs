using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Application.Features.Articles.Queries.GetArticleById;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Articles.Queries.GetArticleByUrl
{
    public class GetArticleByUrlQueryHandler : IRequestHandler<GetArticleByUrlQuery, GetArticleQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly IArticleRepository articleRepository;
        private readonly ILogger<GetArticleByUrlQueryHandler> logger;

        public GetArticleByUrlQueryHandler(IMapper mapper, IArticleRepository articleRepository, ILogger<GetArticleByUrlQueryHandler> logger)
        {
            this.mapper = mapper;
            this.articleRepository = articleRepository;
            this.logger = logger;
        }

        public async Task<GetArticleQueryResponse> Handle(GetArticleByUrlQuery request, CancellationToken cancellationToken)
        {
            var article = await articleRepository.GetArticleByUrl(request.Url);
            return mapper.Map<GetArticleQueryResponse>(article);
        }
    }
}
