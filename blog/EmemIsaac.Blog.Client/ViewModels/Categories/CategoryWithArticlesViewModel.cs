using EmemIsaac.Blog.Client.ViewModels.Articles;

namespace EmemIsaac.Blog.Client.ViewModels.Categories
{
    public class CategoryWithArticlesViewModel
    {
        public string Name { get; set; }

        public string Url { get; private set; }

        public ICollection<ArticlesListItemViewModel> Articles { get; set; }
    }
}
