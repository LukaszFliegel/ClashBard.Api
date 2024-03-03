using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClashBard.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArmyListController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

}
