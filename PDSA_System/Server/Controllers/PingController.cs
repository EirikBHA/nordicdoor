using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PDSA_System.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class PingController : Controller
{
    // GET gir pong hvis den finner bruker
    [HttpGet]
    public IActionResult Index()
    {
        var c = HttpContext;
        Console.WriteLine(c.User.Identity.IsAuthenticated);
        return Ok("pong");
    }
}
