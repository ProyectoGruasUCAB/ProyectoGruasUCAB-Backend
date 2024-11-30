using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace API_GruasUCAB.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class HelloController : ControllerBase
     {
          [HttpGet]
          public string Index()
          {
               return "Hello, world!";
          }

          [HttpGet("token-info")]
          public IActionResult GetTokenInfo()
          {
               var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
               if (string.IsNullOrEmpty(token))
               {
                    return Unauthorized("Token no proporcionado");
               }

               var handler = new JwtSecurityTokenHandler();
               var jwtToken = handler.ReadJwtToken(token);

               var tokenInfo = new
               {
                    Issuer = jwtToken.Issuer,
                    Audience = jwtToken.Audiences,
                    Claims = jwtToken.Claims.Select(c => new { c.Type, c.Value })
               };

               return Ok(tokenInfo);
          }
     }
}
