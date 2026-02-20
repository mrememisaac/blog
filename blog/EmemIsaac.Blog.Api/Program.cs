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
using Microsoft.Extensions.Options;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;

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
    c.CustomSchemaIds(type => type.ToString());
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
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

// builder.WebHost.ConfigureKestrel((context, serverOptions) =>
// {
//     serverOptions.Listen(IPAddress.Loopback, builder.Configuration.GetValue<int>("ASPNETCORE:HTTP:PORT", 7000));
//     serverOptions.Listen(IPAddress.Loopback, builder.Configuration.GetValue<int>("ASPNETCORE:HTTPS:PORT", 7443), listenOptions =>
//     {
//         listenOptions.UseHttps(builder.Configuration.GetValue<string>("ASPNETCORE:Kestrel:Certificates:Default:Path", "EmemIsaac.Blog.Api.pfx"),
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
app.UseCors("Open");

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

