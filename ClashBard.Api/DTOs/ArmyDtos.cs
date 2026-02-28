namespace ClashBard.Api.DTOs;

// === Army Configuration (sent from frontend) ===
public record ArmyConfigurationDto(
    string FactionId,
    int PointsLimit,
    string? GeneralId,
    string? BsbId,
    IReadOnlyList<ArmyCharacterConfigDto> Characters,
    IReadOnlyList<ArmyUnitConfigDto> Units
);

public record ArmyCharacterConfigDto(
    string Id,
    string ModelTypeId,
    string? MountId,
    IReadOnlyList<string> EquippedWeapons,
    IReadOnlyList<string> EquippedArmours,
    IReadOnlyList<string> EquippedSpecialRules,
    IReadOnlyList<string> MagicItemIds,
    string? MagicLevel,
    string? MagicLore,
    bool IsBsb,
    string? MagicStandardId
);

public record ArmyUnitConfigDto(
    string Id,
    string ModelTypeId,
    int Amount,
    bool HasStandard,
    bool HasMusician,
    bool HasChampion,
    IReadOnlyList<string> EquippedWeapons,
    IReadOnlyList<string> EquippedArmours,
    IReadOnlyList<string> EquippedSpecialRules,
    string? MagicStandardId
);

// === Validation Response ===
public record ArmyValidationResponseDto(
    bool IsValid,
    int TotalPoints,
    PointsBreakdownDto PointsBreakdown,
    IReadOnlyList<ValidationErrorDto> Errors
);

public record PointsBreakdownDto(
    int Characters,
    int Core,
    int Special,
    int Rare,
    int Total
);

public record ValidationErrorDto(
    string Message,
    string? Owner
);
