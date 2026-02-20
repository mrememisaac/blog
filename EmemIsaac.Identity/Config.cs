using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace EmemIsaac.Identity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientName = "EmemIsaac.Blog.Administration",
                ClientId = "administration.blog.ememisaac.com",
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris =
                {
                    "https://localhost:44381/signin-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email
                },
                ClientSecrets =
                {
                    new Secret("d7368896-23ac-41ff-9b27-ca555827a2bb-a6af85bf-9208-430d-84ec-21f58dc48f60".ToSha512())
                },
                RequireConsent = true
            },
            new Client
            {
                ClientName = "EmemIsaac.Blog.Api",
                ClientId = "api.blog.ememisaac.com",
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris =
                {
                    "https://localhost:44382/signin-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email
                },
                ClientSecrets =
                {
                    new Secret("12f35d80-565c-4b03-b127-568d5677d070-602ab1cf-5e4d-47b2-955f-f43817e8556d".ToSha512())
                },
                RequireConsent = true
            }
        };
}