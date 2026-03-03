using ClashBard.Api.DTOs;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;

namespace ClashBard.Api.Services;

/// <summary>
/// Composite catalog service that delegates to registered
/// <see cref="IFactionCatalogProvider"/> instances.
/// </summary>
public class CatalogService : ICatalogService
{
    private readonly IReadOnlyDictionary<TowFactionType, IFactionCatalogProvider> _providers;

    public CatalogService(IEnumerable<IFactionCatalogProvider> providers)
    {
        _providers = providers.ToDictionary(p => p.FactionType);
    }

    public IReadOnlyList<FactionSummaryDto> GetFactions()
    {
        return _providers.Values
            .Select(p => new FactionSummaryDto(p.FactionType.ToSlug(), p.FactionType.ToNameString()))
            .OrderBy(f => f.Name)
            .ToList();
    }

    public FactionCatalogDto? GetFactionCatalog(string factionId)
    {
        var factionType = TowFactionTypeExtensions.FromSlug(factionId);
        if (factionType is null) return null;

        return _providers.TryGetValue(factionType.Value, out var provider)
            ? provider.BuildCatalog()
            : null;
    }
}
