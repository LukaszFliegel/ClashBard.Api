using ClashBard.Api.DTOs;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Api.Services;

/// <summary>
/// Provides the full catalog for a single faction.
/// Implement one per faction and register in DI.
/// </summary>
public interface IFactionCatalogProvider
{
    /// <summary>The strongly-typed faction identifier.</summary>
    TowFactionType FactionType { get; }

    /// <summary>Builds the full catalog (characters, units, magic items, composition rules).</summary>
    FactionCatalogDto BuildCatalog();
}
