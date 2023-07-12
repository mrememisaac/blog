using AutoMapper;

namespace EmemIsaac.Blog.BApplication.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Services.Base.GetCategoriesWithArticlesQueryResponse, ViewModels.Categories.CategoryWithArticlesViewModel>();
            CreateMap<ViewModels.Categories.CategoryViewModel, Services.Base.CreateCategoryCommand>();
            CreateMap<ViewModels.Categories.CategoryViewModel, Services.Base.CreateCategoryCommandResponse>().ReverseMap();
            CreateMap<ViewModels.Categories.CategoryViewModel, Services.Base.UpdateCategoryCommand>();
            CreateMap<ViewModels.Categories.CategoryViewModel, Services.Base.GetCategoryModel>().ReverseMap();
        }
    }
}
