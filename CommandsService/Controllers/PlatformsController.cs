using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;

[ApiController]
[Route("api/c/[controller]")]
public class PlatformsController : ControllerBase
{
    public PlatformsController()
    {
        // something here
    }

    [HttpPost]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public ActionResult TestInBoundConnection()
    {
        Console.WriteLine("--> Inbound POST # Command Service");
        return Ok("Inbound test from platforms controller is ok!");
    }
}