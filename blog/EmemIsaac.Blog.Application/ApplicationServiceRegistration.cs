using EmemIsaac.Blog.Application.Features.Articles.Commands.CreateArticle;
using EmemIsaac.Blog.Application.Features.Articles.Commands.UpdateArticle;
using EmemIsaac.Blog.Application.Features.Categories.Commands.CreateCategory;
using EmemIsaac.Blog.Application.Features.Categories.Commands.UpdateCategory;
using EmemIsaac.Blog.Application.Features.Comments.Commands.CreateComment;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmemIsaac.Blog.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<CreateCategoryCommandValidator>();
            services.AddSingleton<UpdateCategoryCommandValidator>();
            services.AddSingleton<CreateCommentCommandValidator>();
            services.AddSingleton<UpdateArticleCommandValidator>();
            services.AddSingleton<CreateArticleCommandValidator>();
            return services;
        }
    }
}
