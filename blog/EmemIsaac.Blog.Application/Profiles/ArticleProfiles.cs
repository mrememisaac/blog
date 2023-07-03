using AutoMapper;
using EmemIsaac.Blog.Application.Features.Articles;
using EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Application.Features.Articles.Commands.UpdateArticle;
using EmemIsaac.Blog.Application.Features.Articles.Queries;
using EmemIsaac.Blog.Application.Features.Articles.Queries.ListArticles;
using EmemIsaac.Blog.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmemIsaac.Blog.Application.Profiles
{
    public class ArticleProfiles : Profile
    {
        public ArticleProfiles()
        {
            CreateMap<CreateArticleCommand, Article>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedDate, opt => opt.Ignore())
                .ForMember(d => d.Category, opt => opt.Ignore())
                .ForMember(d => d.Tags, opt => opt.Ignore())
                .ForMember(d => d.PublishDate, opt => opt.Ignore())
                .ForMember(d => d.Stage, opt => opt.Ignore())
                .ForMember(d => d.Comments, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Article, CreateArticleCommandResponse>();
            CreateMap<Article, GetArticleQueryResponse>()
                .ForMember(d => d.AuthorName, opt => opt.Ignore());
            CreateMap<Article, ListArticlesQueryResponse>()
                .ForMember(d => d.AuthorName, opt => opt.Ignore());
            CreateMap<UpdateArticleCommand, Article>()
                .ForMember(d => d.CreatorId, opt => opt.Ignore())
                .ForMember(d => d.CreateDate, opt => opt.Ignore())
                .ForMember(d => d.PublishDate, opt => opt.Ignore())
                .ForMember(d => d.Category, opt => opt.Ignore())
                .ForMember(d => d.Tags, opt => opt.Ignore())
                .ForMember(d => d.Comments, opt => opt.Ignore())
                .ForMember(d => d.ModifierId, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedDate, opt => opt.Ignore());
            CreateMap<Article, UpdateArticleCommandResponse>();
        }
    }
}
