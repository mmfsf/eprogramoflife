using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace epl.ui.Controllers
{
    [Route("account")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet("token")]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(configuration.GetSection("IdentityServer").GetValue<string>("URI"));
            if (disco.IsError)
            {
                return Ok(disco.Error);
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = configuration.GetSection("IdentityServer").GetValue<string>("client_id"),
                ClientSecret = configuration.GetSection("IdentityServer").GetValue<string>("client_secret"),
                Scope = configuration.GetSection("IdentityServer").GetValue<string>("scope")
            });

            if (tokenResponse.IsError)
            {
                return Ok(tokenResponse.Error);
            }

            return Ok(new 
            { 
                access_token = tokenResponse.AccessToken,
                expires_in = tokenResponse.ExpiresIn,
                token_type = tokenResponse.TokenType
            });
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] string username, [FromQuery] string password)
        {
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync(configuration.GetSection("IdentityServer").GetValue<string>("URI"));
            if (disco.IsError)
            {
                return Problem(disco.Error);
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                GrantType = OidcConstants.GrantTypes.Password,

                ClientId = configuration.GetSection("IdentityServer").GetValue<string>("client_id"),
                ClientSecret = configuration.GetSection("IdentityServer").GetValue<string>("client_secret"),
                Scope = configuration.GetSection("IdentityServer").GetValue<string>("scope"),

                UserName = username,
                Password = password.ToSha256()
            });

            if (tokenResponse.IsError)
            {
                return Problem(tokenResponse.Error);
            }

            return Ok(new
            {
                access_token = tokenResponse.AccessToken,
                expires_in = tokenResponse.ExpiresIn,
                token_type = tokenResponse.TokenType
            });
        }
    }
}