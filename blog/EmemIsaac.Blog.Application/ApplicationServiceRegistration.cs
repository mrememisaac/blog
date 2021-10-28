using EmemIsaac.Blog.Application.Features.Categories.Commands.CreateCategory;
using EmemIsaac.Blog.Application.Features.Categories.Commands.UpdateCategory;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmemIsaac.Blog.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<CreateCategoryCommandValidator>();
            services.AddSingleton<UpdateCategoryCommandValidator>();
            return services;
        }
    }
}
