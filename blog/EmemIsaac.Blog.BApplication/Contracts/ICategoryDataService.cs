using EmemIsaac.Blog.BApplication.ViewModels.Categories;

namespace EmemIsaac.Blog.BApplication.Contracts
{
    public interface ICategoryDataService
    {
        Task DeleteCategory(Guid id);
        
        Task UpdateCategory(CategoryViewModel category);
        
        Task<CategoryViewModel> GetCategory(Guid id);
        
        Task<CategoryViewModel> CreateCategory(CategoryViewModel category);
        
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
        
        Task<IEnumerable<CategoryWithArticlesViewModel>> GetCategoriesWithArticles();
    }
}
