using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SecureController : ControllerBase
{
     [HttpGet]
     [Authorize]
     public IActionResult Get()
     {
          return Ok("This is a secure endpoint");
     }


}