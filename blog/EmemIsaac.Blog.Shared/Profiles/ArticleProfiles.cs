using AutoMapper;
using EmemIsaac.Blog.Shared.ViewModels.Articles;
using EmemIsaac.Blog.Shared.Features.Articles.Commands.UpdateArticle;
using EmemIsaac.Blog.Shared.Features.Articles.Queries;
using EmemIsaac.Blog.Shared.Features.Articles.Queries.ListArticles;

namespace EmemIsaac.Blog.BApplication.Profiles
{
    public class ArticleProfiles : Profile
    {
        public ArticleProfiles()
        {
            CreateMap<ListArticlesQueryResponse, ArticlesListItemViewModel>();
            CreateMap<GetArticleQueryResponse, ArticleViewModel>();
            CreateMap<GetArticleQueryResponse, UpdateArticleViewModel>();
            CreateMap<UpdateArticleViewModel, ArticleViewModel>().ReverseMap();
            CreateMap<UpdateArticleCommandResponse, ArticleViewModel>();
        }
    }
}
