using System.Net;
using Blazored.LocalStorage;
using EmemIsaac.Blog.BApplication.Services;
using EmemIsaac.Blog.Shared.Auth;
using EmemIsaac.Blog.Shared.Contracts;
using EmemIsaac.Blog.Shared.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Authority = builder.Configuration.GetValue<string>("IdentityService:Authority");
    options.ClientId = builder.Configuration.GetValue<string>("IdentityService:ClientId");
    options.ClientSecret = builder.Configuration.GetValue<string>("IdentityService:ClientSecret");
    options.ResponseType = builder.Configuration.GetValue<string>("IdentityService:ResponseType") ?? "code";
    options.CallbackPath = new PathString(builder.Configuration.GetValue<string>("IdentityService:CallbackPath"));
    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;
});
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient<IArticleDataService, ArticlesDataService>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiConfigs:ApiService:Uri")))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<ICategoryDataService, CategoriesDataService>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiConfigs:ApiService:Uri")))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiConfigs:ApiService:Uri")))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
if (!builder.Services.Any(x => x.ServiceType == typeof(HttpClient)))
{
    // Setup HttpClient for server side in a client side compatible fashion
    builder.Services.AddScoped<HttpClient>(s =>
    {
        // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.      
        var uriHelper = s.GetRequiredService<NavigationManager>();
        return new HttpClient
        {
            BaseAddress = new Uri(uriHelper.BaseUri)
        };
    });
}

// builder.WebHost.ConfigureKestrel((context, serverOptions) =>
// {
//     serverOptions.Listen(IPAddress.Loopback, builder.Configuration.GetValue<int>("ASPNETCORE:HTTP:PORT", 8000));
//     serverOptions.Listen(IPAddress.Loopback, builder.Configuration.GetValue<int>("ASPNETCORE:HTTPS:PORT", 8443), listenOptions =>
//     {
//         listenOptions.UseHttps(builder.Configuration.GetValue<string>("ASPNETCORE:Kestrel:Certificates:Default:Path", "EmemIsaac.Blog.Administration.pfx"),
//         builder.Configuration.GetValue<string>("ASPNETCORE:Kestrel:Certificates:Default:Password", "SECRETPASSWORD"));
//     });
// });

//fix for no xml encryptor
builder.Services.AddDataProtection().UseCryptographicAlgorithms(
    new AuthenticatedEncryptorConfiguration
    {
        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
