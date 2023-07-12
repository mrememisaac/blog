using EmemIsaac.Blog.BApplication.Contracts;
using EmemIsaac.Blog.BApplication.Services.Base;
using EmemIsaac.Blog.BApplication.ViewModels.Articles;
using EmemIsaac.Blog.BApplication.ViewModels.Categories;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmemIsaac.Blog.BApplication.Pages.Articles
{
    public partial class Create
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public IArticleDataService ArticleDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CreateArticleViewModel CreateArticleViewModel { get; set; }

        public string Message { get; set; }

        public ObservableCollection<CategoryViewModel> Categories { get; set; } = new ObservableCollection<CategoryViewModel>();

        [Required]
        public Guid SelectedCategoryId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            CreateArticleViewModel = new CreateArticleViewModel();
            var list = await CategoryDataService.GetAllCategories();
            Categories = new ObservableCollection<CategoryViewModel>(list);
        }

        protected async Task HandleValidSubmit()
        {
            CreateArticleViewModel.CategoryId = SelectedCategoryId;
            var response = await ArticleDataService.CreateArticle(CreateArticleViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<CreateArticleCommandResponse> response)
        {
            if (response.Success)
            {
                Message = "Article added";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }

        private Dictionary<string, object> EditorConf = new Dictionary<string, object> {
            { "menubar", true },
            { "plugins", "link image code advcode" },
            { "toolbar", "undo redo | styleselect | forecolor | bold italic | alignleft aligncenter alignright alignjustify | outdent indent | link image | code" }
        };

        private const string ApiKey = "kdjaflkdjdlkdlkdlkjdlkdsfajlkdsdkjl";
    }
}
