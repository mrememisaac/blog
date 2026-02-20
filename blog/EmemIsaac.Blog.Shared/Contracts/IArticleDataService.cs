using EmemIsaac.Blog.Shared.Services.Base;
using EmemIsaac.Blog.Shared.ViewModels.Articles;
using EmemIsaac.Blog.Shared.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Shared.Features.Articles.Commands.UpdateArticle;

namespace EmemIsaac.Blog.Shared.Contracts
{
    public interface IArticleDataService
    {
        Task<ApiResponse<IEnumerable<ArticlesListItemViewModel>>> GetAllArticles();
        
        Task<ApiResponse<ArticleViewModel>> GetArticleByUrl(string url);
        
        Task<ApiResponse<ArticleViewModel>> GetArticleById(Guid id);
        
        Task<ApiResponse<CreateArticleCommandResponse>> CreateArticle(CreateArticleViewModel article);
        
        Task<ApiResponse<UpdateArticleCommandResponse>> UpdateArticle(UpdateArticleViewModel article);

        Task DeleteArticle(Guid id);
    }
}
