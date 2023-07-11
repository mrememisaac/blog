using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Application.UnitTests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.UnitTests.Articles
{
    public class ClassFixtureWithDI
    {
        private readonly ServiceProvider _serviceProvider;

        public ClassFixtureWithDI()
        {
            var services = new ServiceCollection();
            services.AddApplicationServices();
            services.AddScoped<IArticleRepository, ListBasedArticleRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }

        public IArticleRepository ArticleRepository => _serviceProvider.GetService<IArticleRepository>();
    }
}
