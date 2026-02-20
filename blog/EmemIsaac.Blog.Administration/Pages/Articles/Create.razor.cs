using EmemIsaac.Blog.Shared.Contracts;
using EmemIsaac.Blog.Shared.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Shared.Services.Base;
using EmemIsaac.Blog.Shared.ViewModels.Articles;
using EmemIsaac.Blog.Shared.ViewModels.Categories;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmemIsaac.Blog.Administration.Pages.Articles
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
            Categories = new ObservableCollection<CategoryViewModel>(list.Data!);
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
