using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace epl.ui.Controllers
{
    [Route("account")]
    public class AuthenticationController : ControllerBase
    {
        private static string uri = "https://localhost:5001";

        [HttpGet("token")]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(uri);
            if (disco.IsError)
            {
                return Ok(disco.Error);
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "epl.ui",
                ClientSecret = "secret",
                Scope = "epl.api"
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

            var disco = await client.GetDiscoveryDocumentAsync(uri);
            if (disco.IsError)
            {
                return Problem(disco.Error);
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = username,
                ClientSecret = password,

                Scope = "epl.api"
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