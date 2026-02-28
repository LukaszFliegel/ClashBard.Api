using ClashBard.Api.DTOs;
using ClashBard.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClashBard.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArmyController : ControllerBase
{
    private readonly IArmyBuilderService _armyBuilderService;

    public ArmyController(IArmyBuilderService armyBuilderService)
    {
        _armyBuilderService = armyBuilderService;
    }

    /// <summary>
    /// Validates an army configuration and returns errors and points breakdown.
    /// </summary>
    [HttpPost("validate")]
    public ActionResult<ArmyValidationResponseDto> ValidateArmy([FromBody] ArmyConfigurationDto config)
    {
        try
        {
            var result = _armyBuilderService.ValidateArmy(config);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Calculates points breakdown for an army configuration.
    /// </summary>
    [HttpPost("calculate-points")]
    public ActionResult<PointsBreakdownDto> CalculatePoints([FromBody] ArmyConfigurationDto config)
    {
        try
        {
            var result = _armyBuilderService.CalculatePoints(config);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
