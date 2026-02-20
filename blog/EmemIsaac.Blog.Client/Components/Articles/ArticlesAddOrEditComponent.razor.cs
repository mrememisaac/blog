using EmemIsaac.Blog.Client.ViewModels.Articles;
using EmemIsaac.Blog.Client.ViewModels.Categories;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace EmemIsaac.Blog.Client.Components.Articles
{
    public partial class ArticlesAddOrEditComponent
    {
        [Parameter]
        public ArticleViewModel? ArticleViewModel { get; set; }

        [Parameter]
        public string ApiKey { get; set; }

        [Parameter]
        public ObservableCollection<CategoryViewModel> Categories { get; set; } = new ObservableCollection<CategoryViewModel>();

        [Parameter]
        public EventCallback<ArticleViewModel> SubmitButtonClicked { get; set; }

        public Guid SelectedCategoryId { get; set; }

        protected override void OnParametersSet()
        {
            if (ArticleViewModel is not null)
            {
                SelectedCategoryId = ArticleViewModel.CategoryId;
            }
        }
    }
}
