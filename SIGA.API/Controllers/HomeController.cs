using Microsoft.AspNetCore.Mvc;

namespace SIGA.API.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok(new { online = true });
    }
}
