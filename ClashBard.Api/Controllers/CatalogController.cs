using ClashBard.Api.DTOs;
using ClashBard.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClashBard.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly ICatalogService _catalogService;

    public CatalogController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    /// <summary>
    /// Returns the list of available factions.
    /// </summary>
    [HttpGet("factions")]
    public ActionResult<IReadOnlyList<FactionSummaryDto>> GetFactions()
    {
        return Ok(_catalogService.GetFactions());
    }

    /// <summary>
    /// Returns the full catalog (models, magic items, composition rules) for a faction.
    /// </summary>
    [HttpGet("factions/{factionId}")]
    public ActionResult<FactionCatalogDto> GetFactionCatalog(string factionId)
    {
        var catalog = _catalogService.GetFactionCatalog(factionId);
        if (catalog is null) return NotFound();
        return Ok(catalog);
    }
}
