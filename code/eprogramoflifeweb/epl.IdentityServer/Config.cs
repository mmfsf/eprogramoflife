using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace epl.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("epl.api", "Program of Life API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "epl.ui",
                    AllowedGrantTypes = { GrantType.Implicit, GrantType.ClientCredentials, GrantType.ResourceOwnerPassword },
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris =           { "https://localhost:4001/index.html" },
                    PostLogoutRedirectUris = { "https://localhost:4001/index.html" },
                    AllowedCorsOrigins = { "https://localhost:4001" },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "epl.api"
                    },
                    AllowOfflineAccess = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password".Sha256(),
                    IsActive = true,

                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "1"),
                        new Claim(JwtClaimTypes.Name, "Alice"),
                        new Claim(JwtClaimTypes.WebSite, "https://alice.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password".Sha256(),
                    IsActive = true,
                    ProviderName = "Bob Test",

                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Id, "2"),
                        new Claim(JwtClaimTypes.Name, "Bob"),
                        new Claim(JwtClaimTypes.WebSite, "https://bob.com")
                    }
                }
            };
        }

    }
}
