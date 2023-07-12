using EmemIsaac.Blog.BApplication.Services.Base;
using EmemIsaac.Blog.BApplication.ViewModels.Articles;


namespace EmemIsaac.Blog.BApplication.Contracts
{
    public interface IArticleDataService
    {
        Task<IEnumerable<ArticlesListItemViewModel>> GetAllArticles();
        
        Task<ArticleViewModel> GetArticleByUrl(string url);
        
        Task<ArticleViewModel> GetArticleById(Guid id);
        
        Task<ApiResponse<CreateArticleCommandResponse>> CreateArticle(CreateArticleViewModel article);
        
        Task<ApiResponse<Guid>> UpdateArticle(UpdateArticleViewModel article);

        Task DeleteArticle(Guid id);
    }
}
