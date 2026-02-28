using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBard.Tow.Models.ArmyComposition;

/// <summary>
/// Base class for army compositions. Each subclass defines which model types
/// belong to which army slot (Characters/Core/Special/Rare) via SlotMapping,
/// and adds validation rules. The same model type can have different slots
/// in different compositions (e.g. Ellyrian Reavers are Core in Grand Army
/// but Rare in Sea Guard Garrison).
/// </summary>
public abstract class TowArmyComposition : ITowValidatable
{
    /// <summary>
    /// Maps model types to their army slot in this composition.
    /// Populated by each concrete composition subclass.
    /// </summary>
    protected Dictionary<Enum, TowArmySlotType> SlotMapping { get; private set; } = new();

    protected ICollection<ArmyCompositionRule> armyCompositionRules { get; private set; } = new List<ArmyCompositionRule>();

    /// <summary>
    /// Gets the army slot for a given model type in this composition.
    /// Returns null if the model type is not in this composition.
    /// </summary>
    public TowArmySlotType? GetSlot(Enum modelType)
    {
        if (SlotMapping.TryGetValue(modelType, out var slot))
            return slot;
        return null;
    }

    /// <summary>
    /// Returns true if the given model type is allowed in this composition.
    /// </summary>
    public bool IsModelTypeAllowed(Enum modelType)
    {
        return SlotMapping.ContainsKey(modelType);
    }

    public IEnumerable<ValidationError> Validate()
    {
        foreach (var rule in armyCompositionRules)
        {
            foreach (var error in rule.Validate())
            {
                yield return error;
            }
        }
    }
}

public abstract class ArmyCompositionRule : ITowValidatable
{
    public abstract IEnumerable<ValidationError> Validate();
}

/// <summary>
/// Validates that the points spent on a given army slot are within the allowed percentage range.
/// For Characters slot: sums all character costs.
/// For Core/Special/Rare: sums unit costs where the model type maps to that slot.
/// </summary>
public class TowArmyCompositionRuleSlotPercentage : ArmyCompositionRule
{
    private readonly TowArmy army;
    private readonly TowArmyComposition composition;
    private readonly TowArmySlotType slot;
    private readonly int? minPercent;
    private readonly int? maxPercent;

    public TowArmyCompositionRuleSlotPercentage(TowArmy army, TowArmyComposition composition,
        TowArmySlotType slot, int? minPercent = null, int? maxPercent = null)
    {
        this.army = army;
        this.composition = composition;
        this.slot = slot;
        this.minPercent = minPercent;
        this.maxPercent = maxPercent;
    }

    public override IEnumerable<ValidationError> Validate()
    {
        int slotPoints;

        if (slot == TowArmySlotType.Characters)
        {
            slotPoints = army.GetCharacters().Sum(c => c.CalculateTotalCost());
        }
        else
        {
            slotPoints = army.GetUnits()
                .Where(u => composition.GetSlot(u.Model.ModelType) == slot)
                .Sum(u => u.CalculateTotalCost());
        }

        int budget = army.ArmyPoints;

        if (minPercent.HasValue)
        {
            int minRequired = budget * minPercent.Value / 100;
            if (slotPoints < minRequired)
            {
                yield return new ValidationError(
                    $"Not enough points spent on {slot.ToNameString()} units. At least {minPercent}% ({minRequired} pts) required, but only {slotPoints} pts allocated.",
                    "Army Composition");
            }
        }

        if (maxPercent.HasValue)
        {
            int maxAllowed = budget * maxPercent.Value / 100;
            if (slotPoints > maxAllowed)
            {
                yield return new ValidationError(
                    $"Too many points spent on {slot.ToNameString()} units. At most {maxPercent}% ({maxAllowed} pts) allowed, but {slotPoints} pts allocated.",
                    "Army Composition");
            }
        }
    }
}

/// <summary>
/// Validates that all characters and units in the army use model types
/// that are allowed in this composition's SlotMapping.
/// </summary>
public class TowArmyCompositionRuleAllowedModels : ArmyCompositionRule
{
    private readonly TowArmy army;
    private readonly TowArmyComposition composition;

    public TowArmyCompositionRuleAllowedModels(TowArmy army, TowArmyComposition composition)
    {
        this.army = army;
        this.composition = composition;
    }

    public override IEnumerable<ValidationError> Validate()
    {
        foreach (var character in army.GetCharacters())
        {
            if (!composition.IsModelTypeAllowed(character.ModelType))
            {
                yield return new ValidationError(
                    $"{character.ModelType.ToNameString()} is not available in this army composition.",
                    character.ModelType.ToNameString());
            }
        }

        foreach (var unit in army.GetUnits())
        {
            if (!composition.IsModelTypeAllowed(unit.Model.ModelType))
            {
                yield return new ValidationError(
                    $"{unit.Model.ModelType.ToNameString()} is not available in this army composition.",
                    unit.Model.ModelType.ToNameString());
            }
        }
    }
}

/// <summary>
/// Validates that the Battle Standard Bearer (if set) is a model type
/// from the allowed set for this composition.
/// </summary>
public class TowArmyCompositionRuleBsbEligibility : ArmyCompositionRule
{
    private readonly TowArmy army;
    private readonly HashSet<Enum> eligibleModelTypes;

    public TowArmyCompositionRuleBsbEligibility(TowArmy army, HashSet<Enum> eligibleModelTypes)
    {
        this.army = army;
        this.eligibleModelTypes = eligibleModelTypes;
    }

    public override IEnumerable<ValidationError> Validate()
    {
        var bsb = army.BattleStandardBearer;
        if (bsb != null && !eligibleModelTypes.Contains(bsb.ModelType))
        {
            yield return new ValidationError(
                $"{bsb.ModelType.ToNameString()} is not eligible to be a Battle Standard Bearer in this army composition.",
                "Battle Standard Bearer");
        }
    }
}

/// <summary>
/// Limits the combined count of specific unit model types per X army points.
/// Supports both single type ("0-2 Great Eagles per 1,000 pts") and combined
/// types ("0-1 Flamespyre or Frostheart Phoenix per 1,000 pts").
/// </summary>
public class TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<FactionModelEnumType> : ArmyCompositionRule where FactionModelEnumType : Enum
{
    private readonly TowArmy army;
    private readonly FactionModelEnumType[] modelTypes;
    private readonly int upToHowManyUnits;
    private readonly int perHowManyPoints;

    public TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints(TowArmy army, FactionModelEnumType modelType, int upToHowManyUnits, int perHowManyPoints = 1000)
        : this(army, new[] { modelType }, upToHowManyUnits, perHowManyPoints)
    {
    }

    public TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints(TowArmy army, FactionModelEnumType[] modelTypes, int upToHowManyUnits, int perHowManyPoints = 1000)
    {
        this.army = army;
        this.modelTypes = modelTypes;
        this.upToHowManyUnits = upToHowManyUnits;
        this.perHowManyPoints = perHowManyPoints;
    }

    public override IEnumerable<ValidationError> Validate()
    {
        var units = army.GetUnits().Where(u =>
            modelTypes.Any(mt => EqualityComparer<FactionModelEnumType>.Default.Equals((FactionModelEnumType)u.Model.ModelType, mt)));
        var points = army.ArmyPoints;

        if (units.Count() > upToHowManyUnits * points / perHowManyPoints)
        {
            var names = string.Join(" / ", modelTypes.Select(mt => mt.ToNameString()));
            yield return new ValidationError(
                $"Too many units of type {names} in army. Up to {upToHowManyUnits} allowed per {perHowManyPoints} points.",
                names);
        }
    }
}

/// <summary>
/// Limits the combined count of specific character model types per X army points.
/// Supports both single type ("0-1 Dreadlord per 1,000 pts") and combined
/// types ("0-1 Prince or Archmage per 1,000 pts").
/// </summary>
public class TowArmyCompositionRuleZeroToXNumberOfCharactersPerXPoints<FactionModelEnumType> : ArmyCompositionRule where FactionModelEnumType : Enum
{
    private readonly TowArmy army;
    private readonly FactionModelEnumType[] modelTypes;
    private readonly int upToHowManyCharacters;
    private readonly int perHowManyPoints;

    public TowArmyCompositionRuleZeroToXNumberOfCharactersPerXPoints(TowArmy army, FactionModelEnumType modelType, int upToHowManyCharacters, int perHowManyPoints = 1000)
        : this(army, new[] { modelType }, upToHowManyCharacters, perHowManyPoints)
    {
    }

    public TowArmyCompositionRuleZeroToXNumberOfCharactersPerXPoints(TowArmy army, FactionModelEnumType[] modelTypes, int upToHowManyCharacters, int perHowManyPoints = 1000)
    {
        this.army = army;
        this.modelTypes = modelTypes;
        this.upToHowManyCharacters = upToHowManyCharacters;
        this.perHowManyPoints = perHowManyPoints;
    }

    public override IEnumerable<ValidationError> Validate()
    {
        var characters = army.GetCharacters().Where(c =>
            modelTypes.Any(mt => EqualityComparer<FactionModelEnumType>.Default.Equals((FactionModelEnumType)c.ModelType, mt)));
        var points = army.ArmyPoints;

        if (characters.Count() > upToHowManyCharacters * points / perHowManyPoints)
        {
            var names = string.Join(" / ", modelTypes.Select(mt => mt.ToNameString()));
            yield return new ValidationError(
                $"Too many characters of type {names} in army. Up to {upToHowManyCharacters} allowed per {perHowManyPoints} points.",
                names);
        }
    }
}

/// <summary>
/// Enforces an absolute maximum number of units of specific model types,
/// regardless of army points. E.g. "0-1 unit of Lion Guard".
/// Supports both single and combined model types.
/// </summary>
public class TowArmyCompositionRuleMaxNumberOfUnits<FactionModelEnumType> : ArmyCompositionRule where FactionModelEnumType : Enum
{
    private readonly TowArmy army;
    private readonly FactionModelEnumType[] modelTypes;
    private readonly int maxCount;

    public TowArmyCompositionRuleMaxNumberOfUnits(TowArmy army, FactionModelEnumType modelType, int maxCount)
        : this(army, new[] { modelType }, maxCount)
    {
    }

    public TowArmyCompositionRuleMaxNumberOfUnits(TowArmy army, FactionModelEnumType[] modelTypes, int maxCount)
    {
        this.army = army;
        this.modelTypes = modelTypes;
        this.maxCount = maxCount;
    }

    public override IEnumerable<ValidationError> Validate()
    {
        var units = army.GetUnits().Where(u =>
            modelTypes.Any(mt => EqualityComparer<FactionModelEnumType>.Default.Equals((FactionModelEnumType)u.Model.ModelType, mt)));

        if (units.Count() > maxCount)
        {
            var names = string.Join(" / ", modelTypes.Select(mt => mt.ToNameString()));
            yield return new ValidationError(
                $"Too many units of type {names} in army. Maximum {maxCount} allowed.",
                names);
        }
    }
}

/// <summary>
/// Limits the count of specific character mount types per X army points.
/// E.g. "0-1 Star Dragon mount per 1,000 points".
/// </summary>
public class TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<FactionModelMountEnumType> : ArmyCompositionRule where FactionModelMountEnumType : Enum
{
    private readonly TowArmy army;
    private readonly FactionModelMountEnumType modelType;
    private readonly int upToHowManyUnits;
    private readonly int perHowManyPoints;

    public TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints(TowArmy army, FactionModelMountEnumType modelType, int upToHowManyUnits, int perHowManyPoints = 1000)
    {
        this.army = army;
        this.modelType = modelType;
        this.upToHowManyUnits = upToHowManyUnits;
        this.perHowManyPoints = perHowManyPoints;
    }

    public override IEnumerable<ValidationError> Validate()
    {
        var mounts = army.GetCharacters().Where(u => u.Mount != null && EqualityComparer<FactionModelMountEnumType>.Default.Equals((FactionModelMountEnumType)u.Mount.ModelMountType, modelType));
        var points = army.ArmyPoints;

        if (mounts.Count() > upToHowManyUnits * points / perHowManyPoints)
        {
            yield return new ValidationError($"Too many mounts of type {modelType.ToNameString()} in army. Up to {upToHowManyUnits} allowed per {perHowManyPoints} points.", modelType.ToNameString());
        }
    }
}