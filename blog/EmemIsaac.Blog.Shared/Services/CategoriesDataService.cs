using AutoMapper;
using Blazored.LocalStorage;
using EmemIsaac.Blog.BApplication.Services.Base;
using EmemIsaac.Blog.Shared.Contracts;
using EmemIsaac.Blog.Shared.Services.Base;
using EmemIsaac.Blog.Shared.ViewModels.Categories;
using System.Text.Json;

namespace EmemIsaac.Blog.Shared.Services
{
    public class CategoriesDataService : BaseDataService, ICategoryDataService
    {
        private readonly HttpClient _client;

        public CategoriesDataService(HttpClient client, IMapper mapper, ILocalStorageService localStorageService)
            : base(client, localStorageService, mapper)
        {
            _serviceAddress = "api/categories";
        }

        public async Task<ApiResponse<CategoryViewModel>> CreateCategory(CategoryViewModel category)
        {
            return await PostAsync<CategoryViewModel, CategoryViewModel>(category);
        }

        public async Task DeleteCategory(Guid id)
        {
            await DeleteAsync(id);
        }

        public async Task<ApiResponse<IEnumerable<CategoryViewModel>>> GetAllCategories()
        {
            return await GetAll<CategoryViewModel>();
        }

        public async Task<ApiResponse<IEnumerable<CategoryWithArticlesViewModel>>> GetCategoriesWithArticles()
        {
            await AddBearerToken();
            try
            {
                var responseStream = await _client.GetStreamAsync($"{_serviceAddress}/include-articles");
                var data = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryWithArticlesViewModel>>(responseStream, _jsonSerializerOptions);
                return new ApiResponse<IEnumerable<CategoryWithArticlesViewModel>> { Data = data, Success = true };
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<CategoryWithArticlesViewModel>> { Success = false, Message = ex.Message };
            }            
        }

        public async Task<ApiResponse<CategoryViewModel>> GetCategory(Guid id)
        {
            return await GetByIdOrUrl<Guid, CategoryViewModel>(id);
        }

        public async Task<ApiResponse<CategoryViewModel>> UpdateCategory(CategoryViewModel category)
        {
            return await PutAsync<CategoryViewModel, CategoryViewModel>(category);
        }
    }
}
