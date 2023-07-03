using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Articles.Queries.GetArticleById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, GetArticleQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly IArticleRepository articleRepository;
        private readonly ILogger<GetArticleByIdQueryHandler> logger;

        public GetArticleByIdQueryHandler(IMapper mapper, IArticleRepository articleRepository, ILogger<GetArticleByIdQueryHandler> logger)
        {
            this.mapper = mapper;
            this.articleRepository = articleRepository;
            this.logger = logger;
        }

        public async Task<GetArticleQueryResponse> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await articleRepository.GetById(request.Id);
            return mapper.Map<GetArticleQueryResponse>(article);
        }
    }
}
