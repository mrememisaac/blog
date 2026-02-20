namespace EmemIsaac.Blog.Shared.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; private set; }
    }
}
