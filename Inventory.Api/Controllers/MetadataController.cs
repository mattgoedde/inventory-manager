using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetadataController : ControllerBase
{
    [HttpGet("health")]
    public ActionResult<DateTime> Health()
    {
        return Ok(DateTime.UtcNow);
    }
}
