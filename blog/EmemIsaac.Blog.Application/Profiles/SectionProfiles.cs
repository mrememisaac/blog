using AutoMapper;
using EmemIsaac.Blog.Application.Features.Articles;
using EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Domain.Entities;

namespace EmemIsaac.Blog.Application.Profiles
{
    public partial class SectionProfiles : Profile
    {

        public SectionProfiles()
        {
            CreateMap<NewArticleSection, Section>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ArticleId, opt => opt.Ignore())
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.ModifyDate, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Section, Features.Articles.ArticleSection>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
