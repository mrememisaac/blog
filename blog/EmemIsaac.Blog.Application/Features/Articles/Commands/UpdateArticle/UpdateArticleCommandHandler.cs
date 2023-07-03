using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, UpdateArticleCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ILogger<UpdateArticleCommandHandler> logger;
        private readonly UpdateArticleCommandValidator validator;
        private readonly IArticleRepository articleRepository;

        public UpdateArticleCommandHandler(IMapper mapper,
            ILogger<UpdateArticleCommandHandler> logger,
            UpdateArticleCommandValidator validator,
            IArticleRepository articleRepository)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.validator = validator;
            this.articleRepository = articleRepository;
        }

        public async Task<UpdateArticleCommandResponse> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var article = mapper.Map<Domain.Entities.Article>(request);
            await articleRepository.Update(article);
            return mapper.Map<UpdateArticleCommandResponse>(article);
        }
    }
}
