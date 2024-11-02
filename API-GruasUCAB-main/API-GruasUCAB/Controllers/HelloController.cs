using Microsoft.AspNetCore.Mvc;

namespace API_GruasUCAB.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class HelloController : ControllerBase
     {
          [HttpGet]
          public string Index()
          {
               return $"Hello World! {DateTime.Now}.";
          }
     }
}