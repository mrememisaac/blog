using AutoMapper;
using EmemIsaac.Blog.Shared.Contracts;
using EmemIsaac.Blog.Shared.Features.Articles.Commands.UpdateArticle;
using EmemIsaac.Blog.Shared.Services.Base;
using EmemIsaac.Blog.Shared.ViewModels.Articles;
using EmemIsaac.Blog.Shared.ViewModels.Categories;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmemIsaac.Blog.Administration.Pages.Articles
{
    public partial class Edit
    {
        [Inject]
        private ICategoryDataService _categoryDataService { get; set; }

        [Inject]
        private IArticleDataService _articleDataService { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Inject]
        private ILogger<Index> _logger { get; set; }


        [Inject]
        private IMapper _mapper { get; set; }

        
        public ArticleViewModel ArticleViewModel { get; set; }

        public string Message { get; set; }

        public ObservableCollection<CategoryViewModel> Categories { get; set; } = new ObservableCollection<CategoryViewModel>();

        [Required]
        public Guid SelectedCategoryId { get; set; }

        [Parameter]
        public string ArticleUrl { get; set; }
        
        private bool PositiveMessage { get;set; }

        protected async override Task OnInitializedAsync()
        {
            Loading = true;
            var response = await _articleDataService.GetArticleByUrl(ArticleUrl);
            if (response != null && response.Data != null)
            {
                response.Data.AuthorName = response.Data.AuthorName ?? "Emem Isaac";
                ArticleViewModel = response.Data;
                var listOfCategories = await _categoryDataService.GetAllCategories();
                Categories = new ObservableCollection<CategoryViewModel>(listOfCategories.Data!);
                Loading = false;
                return;
            }
            Loading = false;
            //Message = ArticleViewModel == null ? "Article with title @ArticleUrl was not found" : "";
            Message = response != null ? response.Message : "";
        }

        protected async Task HandleSubmit(bool isValid = true)
        {
            if(!isValid || Loading || ArticleViewModel == null)
            {
                Message = null;
                return;
            }
            ArticleViewModel.CategoryId = ArticleViewModel.Category.Id;
            var updateDto = _mapper.Map<UpdateArticleViewModel>(ArticleViewModel);
            Console.WriteLine(updateDto);
            var response = await _articleDataService.UpdateArticle(updateDto);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<UpdateArticleCommandResponse> response)
        {
            if (response.Success)
            {
                Message = "Article updated";
                PositiveMessage = true;
            }
            else
            {
                PositiveMessage = false;
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

        private bool Loading { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            
        }
    }
}
