namespace EmemIsaac.Blog.Client.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; private set; }
    }
}
