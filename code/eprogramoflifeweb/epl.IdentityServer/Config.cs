using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace epl.IdentityServer
{
    public class Config
    {
        // scopes define the resources in your system
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

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "epl.reactui",
                    AllowedGrantTypes = { GrantType.Implicit, GrantType.ClientCredentials },
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
                    }
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
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Bob"),
                        new Claim("website", "https://bob.com")
                    }
                }
            };
        }
    }
}
