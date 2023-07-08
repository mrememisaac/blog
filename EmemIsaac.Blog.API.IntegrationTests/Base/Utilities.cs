using EmemIsaac.Blog.Domain.Entities;
using EmemIsaac.Blog.Persistence;

namespace EmemIsaac.Blog.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeTestDb(BlogDbContext context)
        {
            var cat1 = context.Categories.Add(new Category("Category 1")).Entity;
            cat1.CreateDate = DateTime.Now;
            cat1.CreatorId = "seeder";

            var cat2 = context.Categories.Add(new Category("Category 2")).Entity;
            cat2.CreateDate = DateTime.Now;
            cat2.CreatorId = "seeder";

            var article1 = new Article(Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    "Sample Article", "https://localhost/imageurl", "sample-article", "Description of Sample Article",
                    "Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure? [33] On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain"
            );
            article1.CategoryId = cat1.Id;
            article1.CreateDate = DateTime.Now;
            article1.CreatorId = "seeder";
            context.Articles.Add(article1);
            var result = context.SaveChanges();

            var article2 = new Article(Guid.Parse("{A0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                "Second Sample Article", "https://localhost/imageurl", "second-sample-article", "Description of Second Sample Article",
                "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available. It is also used to temporarily replace text in a process called greeking, which allows designers to consider the form of a webpage or publication, without the meaning of the text influencing the design"
            );
            article2.CategoryId = cat2.Id;
            article2.CreateDate = DateTime.Now;
            article2.CreatorId = "seeder";
            context.Articles.Add(article2);
            result = context.SaveChanges();
            context.SaveChanges();
        }
    }
}