using EmemIsaac.Blog.Api.Services;
using EmemIsaac.Blog.Application;
using EmemIsaac.Blog.Persistence;
using EmemIsaac.Blog.Application.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using EmemIsaac.Blog.Api;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddApplicationServices();
services.AddPersistenceServices(builder.Configuration);
services.AddHttpContextAccessor();
services.AddScoped<ILoggedInUserService, LoggedInUserService>();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmemIsaac.Blog.Api", Version = "v1" });
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmemIsaac.Blog.Api v1"));
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
if (app.Environment.IsDevelopment())
{
    await app.ResetDatabaseAsync();
    await app.SeedDatabase();
}

app.Run();

public partial class Program { }

