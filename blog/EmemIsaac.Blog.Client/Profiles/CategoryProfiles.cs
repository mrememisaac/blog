using AutoMapper;
using EmemIsaac.Blog.Shared.Features.Categories.Commands.CreateCategory;
using EmemIsaac.Blog.Shared.Features.Categories.Queries.GetCategories;
using EmemIsaac.Blog.Shared.Features.Categories.Queries.GetCategoriesWithArticles;

namespace EmemIsaac.Blog.Client.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<GetCategoriesWithArticlesQueryResponse, ViewModels.Categories.CategoryWithArticlesViewModel>();
            CreateMap<ViewModels.Categories.CategoryViewModel, CreateCategoryCommandResponse>().ReverseMap();
            CreateMap<ViewModels.Categories.CategoryViewModel, GetCategoryModel>().ReverseMap();
        }
    }
}
