using ClashBard.Api.DTOs;

namespace ClashBard.Api.Services;

public interface ICatalogService
{
    IReadOnlyList<FactionSummaryDto> GetFactions();
    FactionCatalogDto? GetFactionCatalog(string factionId);
}
