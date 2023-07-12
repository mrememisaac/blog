using EmemIsaac.Blog.BApplication.ViewModels.Articles;

namespace EmemIsaac.Blog.BApplication.ViewModels.Categories
{
    public class CategoryWithArticlesViewModel
    {
        public string Name { get; set; }

        public string Url { get; private set; }

        public ICollection<ArticlesListItemViewModel> Articles { get; set; }
    }
}
