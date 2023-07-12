using EmemIsaac.Blog.BApplication.Contracts;
using EmemIsaac.Blog.BApplication.ViewModels.Articles;
using EmemIsaac.Blog.BApplication.ViewModels.Categories;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmemIsaac.Blog.BApplication.Pages
{
    public partial class Index
    {
        [Inject]
        public IArticleDataService ArticleDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Message { get; set; }

        public ObservableCollection<ArticlesListItemViewModel> Articles { get; set; } = new ObservableCollection<ArticlesListItemViewModel>();

        [Required]
        public Guid SelectedArticleId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var list = await ArticleDataService.GetAllArticles();
            Articles = new ObservableCollection<ArticlesListItemViewModel>(list);
        }
    }
}
