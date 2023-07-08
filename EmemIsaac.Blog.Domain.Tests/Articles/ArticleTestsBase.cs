using AutoMapper;
using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Application.Profiles;
using EmemIsaac.Blog.Application.UnitTests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace EmemIsaac.Blog.Application.UnitTests.Articles
{
    public class ArticleTestsBase
    {
        protected readonly IMapper mapper;
        protected readonly IArticleRepository articleRepository;
        protected readonly CancellationToken cancellationToken;
        protected readonly IServiceProvider _serviceProvider;

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

            var services = new ServiceCollection();
            services.AddApplicationServices();
            services.AddScoped<IArticleRepository, ListBasedArticleRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }

    }
}