using AutoMapper;
using Blazored.LocalStorage;
using EmemIsaac.Blog.BApplication.Contracts;
using EmemIsaac.Blog.BApplication.Services.Base;
using EmemIsaac.Blog.BApplication.ViewModels.Categories;

namespace EmemIsaac.Blog.BApplication.Services
{
    public class CategoriesDataService : BaseDataService, ICategoryDataService
    {
        private readonly IMapper _mapper;

        public CategoriesDataService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<CategoryViewModel> CreateCategory(CategoryViewModel category)
        {
            await AddBearerToken();

            var newCategory = await _client.CreateCategoryAsync(new CreateCategoryCommand { Name = category.Name });
            var mapped = _mapper.Map<CategoryViewModel>(newCategory);
            return mapped;
        }

        public async Task DeleteCategory(Guid id)
        {
            await AddBearerToken();

            await _client.DeleteCategoryAsync(id);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            await AddBearerToken();

            var allCategories = await _client.GetAllCategoriesAsync();
            var mappedCategories = _mapper.Map<ICollection<CategoryViewModel>>(allCategories);
            return mappedCategories.ToList();
        }

        public async Task<IEnumerable<CategoryWithArticlesViewModel>> GetCategoriesWithArticles()
        {
            await AddBearerToken();

            var categoriesWithArticles = await _client.GetCategoriesWithArticlesAsync();
            var mapped = _mapper.Map<ICollection<CategoryWithArticlesViewModel>>(categoriesWithArticles);
            return mapped.ToList();
        }

        public async Task<CategoryViewModel> GetCategory(Guid id)
        {
            var category = await _client.GetCategoryAsync(new GetCategoryQuery { Id = id });
            var mapped = _mapper.Map<CategoryViewModel>(category);
            return mapped;
        }

        public async Task UpdateCategory(CategoryViewModel category)
        {
            await AddBearerToken();

            await _client.UpdateCategoryAsync(new UpdateCategoryCommand { Id = category.Id, Name = category.Name });
        }
    }
}
