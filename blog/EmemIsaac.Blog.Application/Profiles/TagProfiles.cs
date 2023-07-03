using AutoMapper;
using EmemIsaac.Blog.Application.Features.Articles;
using EmemIsaac.Blog.Domain.Entities;

namespace EmemIsaac.Blog.Application.Profiles
{
    public class TagProfiles : Profile
    {
        public TagProfiles()
        {
            CreateMap<Tag, ArticleTag>();
        }
    }
}
