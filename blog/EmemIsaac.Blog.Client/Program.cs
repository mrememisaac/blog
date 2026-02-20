using Blazored.LocalStorage;
using EmemIsaac.Blog.Client.Auth;
using EmemIsaac.Blog.Client.Contracts;
using EmemIsaac.Blog.BApplication.Services;
using EmemIsaac.Blog.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EmemIsaac.Blog.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IArticleDataService, ArticlesDataService>(client => client.BaseAddress = new Uri("https://localhost:5001"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<ICategoryDataService, CategoriesDataService>(client => client.BaseAddress = new Uri("https://localhost:5001"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(client => client.BaseAddress = new Uri("https://localhost:5001"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

await builder.Build().RunAsync();
