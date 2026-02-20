using EmemIsaac.Blog.Client.Contracts;
using EmemIsaac.Blog.Client.ViewModels.Articles;
using Microsoft.AspNetCore.Components;

namespace EmemIsaac.Blog.Client.Pages.Articles
{
    public partial class Index
    {
        [Inject]
        private IArticleDataService _articleDataService { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Inject]
        private ILogger<Index> _logger { get; set; }

        [Parameter]
        public string ArticleUrl { get; set; }

        protected ArticleViewModel? Article { get; set; }

        private string Message { get; set; }

        public bool IsAdministrator { get; set; }

        public string PageTitle { get; set; } = "";

        protected async override Task OnInitializedAsync()
        {
            var response = await _articleDataService.GetArticleByUrl(ArticleUrl);
            if (response != null && response.Data != null)
            {
                response.Data.AuthorName = response.Data.AuthorName ?? "Emem Isaac";
                Article = response.Data;
                PageTitle = response.Data.Title;
                return;
            }
            Message = response != null ? response.Message : "";
        }
    }
}
