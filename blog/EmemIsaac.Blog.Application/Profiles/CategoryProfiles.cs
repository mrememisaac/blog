using AutoMapper;
using EmemIsaac.Blog.Domain.Entities;

namespace EmemIsaac.Blog.Application.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Article, Features.Categories.Queries.GetCategory.GetCategoryArticle>()
                .ForMember(d => d.AuthorName, opt => opt.Ignore());
            CreateMap<Features.Categories.Queries.GetCategory.GetCategoryModel, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedDate, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ForMember(d => d.Articles, opt => opt.Ignore())
                .ForMember(d => d.Url, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Features.Categories.Queries.GetCategories.GetCategoryModel, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedDate, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ForMember(d => d.Articles, opt => opt.Ignore())
                .ForMember(d => d.Url, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Features.Categories.Queries.GetCategoriesWithArticles.GetCategoriesWithArticlesQueryResponse, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedDate, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ForMember(d => d.Articles, opt => opt.Ignore())
                .ForMember(d => d.Url, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Features.Categories.Commands.CreateCategory.CreateCategoryModel, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedDate, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ForMember(d => d.Articles, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Features.Categories.Commands.CreateCategory.CreateCategoryCommand, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedDate, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ForMember(d => d.Articles, opt => opt.Ignore())
                .ForMember(d => d.Articles, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
