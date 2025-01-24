using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_GruasUCAB.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class HelloController : ControllerBase
     {
          [HttpGet]
          [Authorize]
          public IActionResult Get()
          {
               return Ok("Hello World!");
          }
     }
}
