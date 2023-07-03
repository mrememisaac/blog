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
            var article1 = new Article(Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    "Sample Article", "https://localhost/imageurl", "sample-article", "Description of Sample Article");
            article1.Sections.Add(
                new Section { ArticleId = article1.Id, Content = "Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure? [33] On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain" }
            );
            articles.Add(article1);

            var article2 = new Article(Guid.Parse("{A0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"), "Second Sample Article", "https://localhost/imageurl", "second-sample-article", "Description of Second Sample Article");
            article2.Sections.Add(
                new Section { ArticleId = article2.Id, Content = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available. It is also used to temporarily replace text in a process called greeking, which allows designers to consider the form of a webpage or publication, without the meaning of the text influencing the design" }
            );
            articles.Add(article2);

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
