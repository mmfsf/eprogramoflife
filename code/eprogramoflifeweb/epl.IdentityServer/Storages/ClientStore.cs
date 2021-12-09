using epl.core.Domain;
using epl.core.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace epl.IdentityServer.Storages
{
    public class ClientStore : IClientStore
    {
        private IAsyncRepository<Account> repository;

        public ClientStore(IAsyncRepository<Account> repository)
        {
            this.repository = repository;
        }
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var appClient = await repository.Get(clientId);
            return new Client
            {
                ClientId = appClient.ClientId,
                AllowedGrantTypes = { GrantType.Implicit, GrantType.ClientCredentials, GrantType.ResourceOwnerPassword },
                AllowAccessTokensViaBrowser = true,
                ClientSecrets = appClient.ClientSecrets.Select(x => new Secret(x.Sha256())).ToList(),
                AllowedScopes = appClient.AllowedScopes,
                AllowOfflineAccess = true,
                RedirectUris = { "https://localhost:4001/index.html" },
                PostLogoutRedirectUris = { "https://localhost:4001/index.html" },
                AllowedCorsOrigins = { "https://localhost:4001" }
            };
        }
    }
}
