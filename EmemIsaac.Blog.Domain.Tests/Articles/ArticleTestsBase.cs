using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Application.Profiles;
using EmemIsaac.Blog.Application.UnitTests.Mocks;
using Moq;
using System.Threading;

namespace EmemIsaac.Blog.Application.UnitTests.Articles
{
    public class ArticleTestsBase
    {
        protected readonly IMapper mapper;
        protected readonly IArticleRepository articleRepository;
        protected readonly CancellationToken cancellationToken;

        public ArticleTestsBase()
        {
            cancellationToken = new CancellationToken();
            articleRepository = RepositoryMocks.GetListBasedArticleRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategoryProfiles>();
                cfg.AddProfile<CommentProfiles>();
                cfg.AddProfile<SectionProfiles>();
                cfg.AddProfile<TagProfiles>();
                cfg.AddProfile<ArticleProfiles>();
            });
            mapper = configurationProvider.CreateMapper();
        }

    }
}