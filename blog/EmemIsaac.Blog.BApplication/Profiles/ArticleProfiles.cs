using AutoMapper;

namespace EmemIsaac.Blog.BApplication.Profiles
{
    public class ArticleProfiles : Profile
    {
        public ArticleProfiles()
        {
            CreateMap<Services.Base.ListArticlesQueryResponse, ViewModels.Articles.ArticlesListItemViewModel>();
            CreateMap<Services.Base.GetArticleQueryResponse, ViewModels.Articles.ArticleViewModel>();
            CreateMap<ViewModels.Articles.CreateArticleViewModel, Services.Base.CreateArticleCommand>();
            CreateMap<ViewModels.Articles.ArticleViewModel, Services.Base.CreateArticleCommandResponse>();
            CreateMap<ViewModels.Articles.UpdateArticleViewModel, Services.Base.UpdateArticleCommand>();
        }
    }
}
