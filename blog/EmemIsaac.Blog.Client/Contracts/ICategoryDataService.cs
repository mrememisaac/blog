using EmemIsaac.Blog.Client.Services.Base;
using EmemIsaac.Blog.Client.ViewModels.Categories;

namespace EmemIsaac.Blog.Client.Contracts
{
    public interface ICategoryDataService
    {
        Task DeleteCategory(Guid id);

        Task<ApiResponse<CategoryViewModel>> UpdateCategory(CategoryViewModel category);
        
        Task<ApiResponse<CategoryViewModel>> GetCategory(Guid id);
        
        Task<ApiResponse<CategoryViewModel>> CreateCategory(CategoryViewModel category);
        
        Task<ApiResponse<IEnumerable<CategoryViewModel>>> GetAllCategories();
        
        Task<ApiResponse<IEnumerable<CategoryWithArticlesViewModel>>> GetCategoriesWithArticles();
    }
}
