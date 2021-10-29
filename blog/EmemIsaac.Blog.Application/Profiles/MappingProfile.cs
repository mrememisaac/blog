using AutoMapper;
using EmemIsaac.Blog.Domain.Entities;

namespace EmemIsaac.Blog.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Category
            CreateMap<Features.Categories.Queries.GetCategory.Article, Article>().ReverseMap();
            CreateMap<Features.Categories.Queries.GetCategory.GetCategoryModel, Category>().ReverseMap();
            CreateMap<Features.Categories.Queries.GetCategories.GetCategoryModel, Category>().ReverseMap();
            CreateMap<Features.Categories.Queries.GetCategoriesWithArticles.Category, Category>().ReverseMap();
            CreateMap<Features.Categories.Commands.CreateCategory.CreateCategoryModel, Category>().ReverseMap();
            CreateMap<Features.Categories.Commands.CreateCategory.CreateCategoryCommand, Category>().ReverseMap();

            //Comment
            CreateMap<Features.Comments.Commands.CreateComment.CreateCommentCommand, Category>().ReverseMap();
            CreateMap<Features.Comments.Commands.CreateComment.CreateCommentModel, Category>().ReverseMap();
        }
    }
}
