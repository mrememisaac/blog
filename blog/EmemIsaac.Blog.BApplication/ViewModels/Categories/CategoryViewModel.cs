namespace EmemIsaac.Blog.BApplication.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; private set; }
    }
}
