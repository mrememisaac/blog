using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ILogger<CreateArticleCommandHandler> logger;
        private readonly CreateArticleCommandValidator validator;
        private readonly IArticleRepository articleRepository;

        public CreateArticleCommandHandler(IMapper mapper, 
            ILogger<CreateArticleCommandHandler> logger, 
            CreateArticleCommandValidator validator,
            IArticleRepository articleRepository)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.validator = validator;
            this.articleRepository = articleRepository;
        }
        public async Task<CreateArticleCommandResponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var article = await articleRepository.Add(mapper.Map<Article>(request));
            return mapper.Map<CreateArticleCommandResponse>(article);
        }
    }
}
