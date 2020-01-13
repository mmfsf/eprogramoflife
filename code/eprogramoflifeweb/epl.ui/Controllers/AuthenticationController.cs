using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace epl.ui.Controllers
{
    [Route("/token")]
    public class AuthenticationController : Controller
    {
        public async Task<IActionResult> Get()
        {
            var uri = "https://localhost:5001";
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

            return Json(new { 
                access_token = tokenResponse.AccessToken,
                expires_in = tokenResponse.ExpiresIn,
                token_type = tokenResponse.TokenType
            });
        }
    }
}