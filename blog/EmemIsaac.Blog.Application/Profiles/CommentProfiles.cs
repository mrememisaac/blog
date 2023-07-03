using AutoMapper;
using EmemIsaac.Blog.Domain.Entities;

namespace EmemIsaac.Blog.Application.Profiles
{
    public class CommentProfiles : Profile
    {
        public CommentProfiles()
        {
            CreateMap<Features.Comments.Commands.CreateComment.CreateCommentCommand, Comment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedDate, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ForMember(d => d.Article, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Features.Comments.Commands.CreateComment.CreateCommentModel, Comment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedDate, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ForMember(d => d.Article, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Comment, Features.Articles.ArticleComment>();
        }
    }
}
