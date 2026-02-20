using Blazored.LocalStorage;
using EmemIsaac.Blog.Shared.Auth;
using EmemIsaac.Blog.BApplication;
using EmemIsaac.Blog.BApplication.Services;
using EmemIsaac.Blog.Shared.Contracts;
using EmemIsaac.Blog.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient<IArticleDataService, ArticlesDataService>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiConfigs:ApiService:Uri")))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<ICategoryDataService, CategoriesDataService>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiConfigs:ApiService:Uri")))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiConfigs:ApiService:Uri")))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
//builder.Services.AddServerSideBlazor();
//if (!builder.Services.Any(x => x.ServiceType == typeof(HttpClient)))
//{
//    // Setup HttpClient for server side in a client side compatible fashion
//    builder.Services.AddScoped<HttpClient>(s =>
//    {
//        // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.      
//        var uriHelper = s.GetRequiredService<NavigationManager>();
//        return new HttpClient
//        {
//            BaseAddress = new Uri(uriHelper.BaseUri)
//        };
//    });
//}
await builder.Build().RunAsync();
