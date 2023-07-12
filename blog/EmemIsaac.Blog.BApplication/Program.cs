using Blazored.LocalStorage;
using EmemIsaac.Blog.BApplication;
using EmemIsaac.Blog.BApplication.Auth;
using EmemIsaac.Blog.BApplication.Contracts;
using EmemIsaac.Blog.BApplication.Services.Base;
using EmemIsaac.Blog.BApplication.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, ServiceClient>(client => client.BaseAddress = new Uri("https://localhost:5001"))
.AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped<IArticleDataService, ArticlesDataService>();
builder.Services.AddScoped<ICategoryDataService, CategoriesDataService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();
