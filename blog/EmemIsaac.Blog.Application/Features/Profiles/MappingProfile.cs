using AutoMapper;

namespace EmemIsaac.Blog.Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categories.Queries.GetCategory.Article, Domain.Entities.Article>().ReverseMap();
            CreateMap<Categories.Queries.GetCategory.Category, Domain.Entities.Category>().ReverseMap();
            CreateMap<Categories.Queries.GetCategories.Category, Domain.Entities.Category>().ReverseMap();
            CreateMap<Categories.Queries.GetCategoriesWithArticles.Category, Domain.Entities.Category>().ReverseMap();
        }
    }
}
