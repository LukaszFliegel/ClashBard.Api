using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;

namespace ClashBard.Tow.Models.Factions.ArmyCompositions;

/// <summary>
/// The Chracian Warhost – Army of Infamy composition for the High Elf Realms.
/// Focused on Chracian-themed units: White Lions, Lion Chariots, War Lions, Lion Guard.
/// </summary>
/// <remarks>
/// Note: White Lions of Chrace appear in both Core (0-1 per 1,000 points) and Special (unlimited).
/// In the current system a model type maps to a single slot, so White Lions are mapped to Special
/// (their primary slot). The 0-1 per 1,000 points Core allowance is tracked as a unit limit rule
/// but the unit will count toward the Special slot percentage. A future enhancement could support
/// dual-slot unit types.
/// </remarks>
public class HighElvesChracianWarhostComposition : TowArmyComposition
{
    public HighElvesChracianWarhostComposition(TowArmy army)
    {
        // === Slot Mapping ===

        // Characters (up to 50%)
        // 0-1 Prince or Archmage per 1,000 points (combined)
        SlotMapping[HighElvesTowModelType.Prince] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.Archmage] = TowArmySlotType.Characters;
        // 0-1 Chracian Chieftain or Storm Weaver per 1,000 points (combined)
        SlotMapping[HighElvesTowModelType.ChracianChieftain] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.StormWeaver] = TowArmySlotType.Characters;
        // High Elf Nobles (no per-1000 limit)
        SlotMapping[HighElvesTowModelType.Noble] = TowArmySlotType.Characters;

        // Core (at least 33%)
        // Elven Spearmen, Elven Archers and Chracian Woodsmen (no limit)
        SlotMapping[HighElvesTowModelType.Spearmen] = TowArmySlotType.Core;
        SlotMapping[HighElvesTowModelType.Archers] = TowArmySlotType.Core;
        SlotMapping[HighElvesTowModelType.ChracianWoodsmen] = TowArmySlotType.Core;
        // NOTE: 0-1 unit of White Lions of Chrace per 1,000 points can also be taken as Core.
        // See class remarks for dual-slot limitation.

        // Special (up to 50%)
        // White Lions of Chrace (unlimited in Special), Lion Chariots of Chrace
        SlotMapping[HighElvesTowModelType.WhiteLionsOfChrace] = TowArmySlotType.Special;
        SlotMapping[HighElvesTowModelType.LionChariotsOfChrace] = TowArmySlotType.Special;
        // 0-1 unit of War Lions per 1,000 points
        SlotMapping[HighElvesTowModelType.WarLions] = TowArmySlotType.Special;

        // Rare (up to 33%)
        // 0-1 unit of Lion Guard (absolute limit)
        SlotMapping[HighElvesTowModelType.LionGuard] = TowArmySlotType.Rare;
        // 0-1 unit of Shadow Warriors or Sisters of Avelorn per 1,000 points (combined)
        SlotMapping[HighElvesTowModelType.ShadowWarriors] = TowArmySlotType.Rare;
        SlotMapping[HighElvesTowModelType.SistersOfAvelorn] = TowArmySlotType.Rare;
        // 0-2 Great Eagles per 1,000 points
        SlotMapping[HighElvesTowModelType.GreatEagle] = TowArmySlotType.Rare;
        // 0-1 Eagle-Claw Bolt Thrower per 1,000 points
        SlotMapping[HighElvesTowModelType.EagleClawBoltThrower] = TowArmySlotType.Rare;

        // === Percentage Rules ===
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Characters, maxPercent: 50));
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Core, minPercent: 33));
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Special, maxPercent: 50));
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Rare, maxPercent: 33));

        // === Character Limits ===
        // 0-1 Prince or Archmage per 1,000 points (combined)
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfCharactersPerXPoints<HighElvesTowModelType>(
            army, new[] { HighElvesTowModelType.Prince, HighElvesTowModelType.Archmage }, 1));
        // 0-1 Chracian Chieftain or Storm Weaver per 1,000 points (combined)
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfCharactersPerXPoints<HighElvesTowModelType>(
            army, new[] { HighElvesTowModelType.ChracianChieftain, HighElvesTowModelType.StormWeaver }, 1));

        // === Unit Limits ===
        // 0-1 unit of War Lions per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, HighElvesTowModelType.WarLions, 1));
        // 0-1 unit of Lion Guard (absolute limit — no per-1000 qualifier)
        armyCompositionRules.Add(new TowArmyCompositionRuleMaxNumberOfUnits<HighElvesTowModelType>(
            army, HighElvesTowModelType.LionGuard, 1));
        // 0-1 unit of Shadow Warriors or Sisters of Avelorn per 1,000 points (combined)
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, new[] { HighElvesTowModelType.ShadowWarriors, HighElvesTowModelType.SistersOfAvelorn }, 1));
        // 0-2 Great Eagles per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, HighElvesTowModelType.GreatEagle, 2));
        // 0-1 Eagle-Claw Bolt Thrower per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, HighElvesTowModelType.EagleClawBoltThrower, 1));

        // === Model Validation ===
        armyCompositionRules.Add(new TowArmyCompositionRuleAllowedModels(army, this));

        // === BSB Eligibility ===
        // A single High Elf Noble or Chracian Chieftain
        armyCompositionRules.Add(new TowArmyCompositionRuleBsbEligibility(
            army, new HashSet<Enum> { HighElvesTowModelType.Noble, HighElvesTowModelType.ChracianChieftain }));
    }
}
