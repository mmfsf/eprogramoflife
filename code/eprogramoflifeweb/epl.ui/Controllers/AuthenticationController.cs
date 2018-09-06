using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace epl.ui.Controllers
{
  [Route("/token")]
  public class AuthenticationController : Controller
  {
    public async Task<IActionResult> Get()
    {
      var isurl = "https://localhost:5001";
      var disco = await DiscoveryClient.GetAsync(isurl);

      if (disco.IsError)
      {
        return StatusCode(500, new { error = disco.Error });
      }

      var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
      var tokenResponse = await tokenClient.RequestClientCredentialsAsync("epl.api");

      if (tokenResponse.IsError)
      {
        return Json(new { error = tokenResponse.Error });
      }
      return Json(tokenResponse.Json);

    }
  }
}