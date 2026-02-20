using AutoMapper;
using Blazored.LocalStorage;
using EmemIsaac.Blog.Shared.Contracts;
using EmemIsaac.Blog.BApplication.Services.Base;
using EmemIsaac.Blog.Shared.ViewModels.Articles;
using EmemIsaac.Blog.Shared.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Shared.Features.Articles.Commands.UpdateArticle;
using EmemIsaac.Blog.Shared.Services.Base;

namespace EmemIsaac.Blog.BApplication.Services
{

    public class ArticlesDataService : BaseDataService, IArticleDataService
    {
        private readonly HttpClient _client;

        public ArticlesDataService(HttpClient client, IMapper mapper, ILocalStorageService localStorageService) 
            : base(client, localStorageService, mapper)
        {
            _serviceAddress = "api/articles";
        }

        public async Task<ApiResponse<CreateArticleCommandResponse>> CreateArticle(CreateArticleViewModel article)
        {
            return await PostAsync<CreateArticleViewModel, CreateArticleCommandResponse>(article);
        }

        public async Task DeleteArticle(Guid id)
        {
            await DeleteAsync(id);
        }

        public async Task<ApiResponse<IEnumerable<ArticlesListItemViewModel>>> GetAllArticles()
        {
            return await GetAll<ArticlesListItemViewModel>();
        }

        public async Task<ApiResponse<ArticleViewModel>> GetArticleById(Guid id)
        {
            return await GetByIdOrUrl<Guid, ArticleViewModel>(id);
        }

        public async Task<ApiResponse<ArticleViewModel>> GetArticleByUrl(string url)
        {
            return await GetByIdOrUrl<String, ArticleViewModel>(url);
        }

        public async Task<ApiResponse<UpdateArticleCommandResponse>> UpdateArticle(UpdateArticleViewModel article)
        {
            return await PutAsync<UpdateArticleViewModel, UpdateArticleCommandResponse>(article);
        }
    }
}
