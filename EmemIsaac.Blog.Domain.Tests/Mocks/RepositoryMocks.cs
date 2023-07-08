using EmemIsaac.Blog.Application.Contracts.Persistence;
using EmemIsaac.Blog.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.UnitTests.Mocks
{
    public partial class RepositoryMocks
    {
        public static IArticleRepository GetListBasedArticleRepository()
        {
            return new ListBasedArticleRepository();
        }
        public static Mock<IArticleRepository> GetMockArticleRepository()
        {
            var articles = new List<Article>();

            var mockRepository = new Mock<IArticleRepository>();
            mockRepository.Setup(x => x.ListAll()).ReturnsAsync(articles);
            mockRepository.Setup(x => x.GetArticles(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(articles);
            mockRepository.Setup(x => x.Exists(It.Is<Guid>(id => articles.Exists(a => a.Id == id)))).ReturnsAsync(true);
            mockRepository.Setup(x => x.Add(It.IsAny<Article>())).ReturnsAsync((Article newArticle) =>
            {
                articles.Add(newArticle);
                return newArticle;
            });
            mockRepository.Setup(x => x.Update(It.IsAny<Article>())).Returns((Article articleUpdate) =>
            {
                var current = articles.FirstOrDefault(x => x.Id == articleUpdate.Id);
                if (current != null) articles.Remove(current);
                articles.Add(articleUpdate);
                return Task.CompletedTask;
            });
            mockRepository.Setup(x => x.Delete(It.IsAny<Article>())).Returns((Article articleForDelete) =>
            {
                var current = articles.FirstOrDefault(x => x.Id == articleForDelete.Id);
                if (current != null) articles.Remove(current);
                return Task.CompletedTask;
            });
            return mockRepository;
        }
    }
}
