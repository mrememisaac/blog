using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Features.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, BaseResponse>
    {
        private readonly ILogger<DeleteArticleCommandHandler> logger;
        private readonly IArticleRepository articleRepository;

        public DeleteArticleCommandHandler(ILogger<DeleteArticleCommandHandler> logger, IArticleRepository articleRepository)
        {
            this.logger = logger;
            this.articleRepository = articleRepository;
        }

        public async Task<BaseResponse> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await articleRepository.GetById(request.ArticleId);
            if (article == null)
            {
                var msg = $"Article with Id: {request.ArticleId} does not exist";
                logger.LogError(msg);
                throw new Exceptions.BadRequestException(msg);
            }
            await articleRepository.Delete(article);
            return new BaseResponse($"Article with Id: {request.ArticleId} deleted");
        }
    }
}
