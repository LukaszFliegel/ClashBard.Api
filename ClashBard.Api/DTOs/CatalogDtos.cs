namespace ClashBard.Api.DTOs;

// === Faction ===
public record FactionSummaryDto(string Id, string Name);

// === Full Catalog ===
public record FactionCatalogDto(
    string FactionId,
    string FactionName,
    IReadOnlyList<CharacterCatalogDto> Characters,
    IReadOnlyList<UnitModelCatalogDto> Units,
    IReadOnlyList<MagicItemCatalogDto> MagicItems,
    CompositionRulesDto CompositionRules
);

// === Stats ===
public record ModelStatsDto(
    int? Movement,
    int? WeaponSkill,
    int? BallisticSkill,
    int? Strength,
    int? Toughness,
    int? Wounds,
    int? Initiative,
    int? Attacks,
    int? Leadership
);

// === Catalog Option (id + display name + cost) ===
public record CatalogOptionDto(string Id, string Name, int Cost);

// === Mount Catalog ===
public record MountCatalogDto(
    string Id,
    string Name,
    int Cost,
    ModelStatsDto? Stats,
    string TroopType,
    int? ArmorValue,
    int? ToughnessAdded,
    int? WoundsAdded
);

// === Mage Info ===
public record MageInfoDto(
    int BaseLevel,
    IReadOnlyList<CatalogOptionDto> AvailableLevelUpgrades,
    IReadOnlyList<CatalogOptionDto> AvailableLores
);

// === BSB Info ===
public record BsbInfoDto(
    int UpgradeCost,
    int MagicStandardAllowance
);

// === Character Catalog ===
public record CharacterCatalogDto(
    string ModelTypeId,
    string Name,
    int BasePoints,
    ModelStatsDto Stats,
    string TroopType,
    IReadOnlyList<CatalogOptionDto> DefaultWeapons,
    IReadOnlyList<CatalogOptionDto> AvailableWeapons,
    IReadOnlyList<CatalogOptionDto> DefaultArmours,
    IReadOnlyList<CatalogOptionDto> AvailableArmours,
    IReadOnlyList<CatalogOptionDto> AvailableSpecialRules,
    IReadOnlyList<MountCatalogDto> AvailableMounts,
    IReadOnlyList<string> AvailableMagicItemCategories,
    int MagicItemAllowance,
    MageInfoDto? MageInfo,
    BsbInfoDto? BsbInfo
);

// === Command Group ===
public record CommandGroupDto(
    string? ChampionName,
    int? ChampionCost,
    int? StandardCost,
    int? MusicianCost,
    int? MagicStandardAllowance,
    int? ChampionMagicItemAllowance
);

// === Unit Model Catalog ===
public record UnitModelCatalogDto(
    string ModelTypeId,
    string Name,
    string SlotType,
    int PointsPerModel,
    ModelStatsDto Stats,
    string TroopType,
    int MinUnitSize,
    int? MaxUnitSize,
    IReadOnlyList<CatalogOptionDto> DefaultWeapons,
    IReadOnlyList<CatalogOptionDto> AvailableWeapons,
    IReadOnlyList<CatalogOptionDto> DefaultArmours,
    IReadOnlyList<CatalogOptionDto> AvailableArmours,
    IReadOnlyList<CatalogOptionDto> AvailableSpecialRules,
    CommandGroupDto? CommandGroup
);

// === Magic Item Catalog ===
public record MagicItemCatalogDto(
    string Id,
    string Name,
    int Points,
    string Category,
    bool IsFactionSpecific
);

// === Composition Rules ===
public record SlotPercentageRuleDto(string SlotType, int? MinPercent, int? MaxPercent);

public record CompositionRulesDto(
    IReadOnlyList<SlotPercentageRuleDto> SlotPercentages,
    IReadOnlyList<string> BsbEligibleModelTypes
);
