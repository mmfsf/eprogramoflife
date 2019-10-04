using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace epl.reactui.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Authorize()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                return Ok(disco.Error);
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "epl.reactui",
                ClientSecret = "secret",
                Scope = "epl.api"
            });

            if (tokenResponse.IsError)
            {
                return Ok(tokenResponse.Error);
            }

            return Ok(tokenResponse.AccessToken);
        }
    }
}