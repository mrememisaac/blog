using EmemIsaac.Blog.Shared.ViewModels.Articles;

namespace EmemIsaac.Blog.Shared.ViewModels.Categories
{
    public class CategoryWithArticlesViewModel
    {
        public string Name { get; set; }

        public string Url { get; private set; }

        public ICollection<ArticlesListItemViewModel> Articles { get; set; }
    }
}
