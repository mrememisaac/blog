// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace EmemIsaac.Identity;

public class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            var address = new
            {
                street_address = "One Hacker Way",
                locality = "Heidelberg",
                postal_code = 69118,
                country = "Germany"
            };
                
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "emem",
                    Password = "emem",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Emem Isaac"),
                        new Claim(JwtClaimTypes.GivenName, "Emem"),
                        new Claim(JwtClaimTypes.FamilyName, "Isaac"),
                        new Claim(JwtClaimTypes.Email, "EmemIsaac@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://ememisaac.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "rebeccah",
                    Password = "rebeccah",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Rebeccah Isaac"),
                        new Claim(JwtClaimTypes.GivenName, "Rebeccah"),
                        new Claim(JwtClaimTypes.FamilyName, "Isac"),
                        new Claim(JwtClaimTypes.Email, "RebeccahIsaac@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://rebeccahisaac.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                }
            };
        }
    }
}