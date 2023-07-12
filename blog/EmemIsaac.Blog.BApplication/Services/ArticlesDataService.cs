using AutoMapper;
using Blazored.LocalStorage;
using EmemIsaac.Blog.BApplication.Contracts;
using EmemIsaac.Blog.BApplication.Services.Base;
using EmemIsaac.Blog.BApplication.ViewModels.Articles;

namespace EmemIsaac.Blog.BApplication.Services
{

    public class ArticlesDataService : BaseDataService, IArticleDataService
    {
        private readonly IMapper _mapper;

        public ArticlesDataService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<CreateArticleCommandResponse>> CreateArticle(CreateArticleViewModel article)
        {
            await AddBearerToken();

            try
            {
                var response = await _client.CreateArticleAsync(_mapper.Map<CreateArticleCommand>(article));
                return new ApiResponse<CreateArticleCommandResponse> { Success = true, Data = response };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CreateArticleCommandResponse>(ex);
            }
        }

        public async Task DeleteArticle(Guid id)
        {
            await AddBearerToken();

            await _client.DeleteArticleAsync(id);
        }

        public async Task<IEnumerable<ArticlesListItemViewModel>> GetAllArticles()
        {
            await AddBearerToken();
            var response = await _client.GetAllArticlesAsync();
            return _mapper.Map<IEnumerable<ArticlesListItemViewModel>>(response);
        }

        public async Task<ArticleViewModel> GetArticleById(Guid id)
        {
            var response = await _client.GetArticleByIdAsync(id);
            return _mapper.Map<ArticleViewModel>(response);
        }

        public async Task<ArticleViewModel> GetArticleByUrl(string url)
        {
            var response = await _client.GetArticleByUrlAsync(url);
            return _mapper.Map<ArticleViewModel>(response);
        }

        public async Task<ApiResponse<Guid>> UpdateArticle(UpdateArticleViewModel article)
        {
            await AddBearerToken();

            var request = _mapper.Map<UpdateArticleCommand>(article);
            try
            {
                await _client.UpdateArticleAsync(request);
                return new ApiResponse<Guid> { Success = true };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
