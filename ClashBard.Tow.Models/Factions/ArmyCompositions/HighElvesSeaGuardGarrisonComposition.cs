using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;

namespace ClashBard.Tow.Models.Factions.ArmyCompositions;

/// <summary>
/// Sea Guard Garrison – Army of Infamy composition for the High Elf Realms.
/// Focused on Lothern Sea Guard, Ship's Company, and naval-themed units.
/// </summary>
public class HighElvesSeaGuardGarrisonComposition : TowArmyComposition
{
    public HighElvesSeaGuardGarrisonComposition(TowArmy army)
    {
        // === Slot Mapping ===

        // Characters (up to 50%)
        // Sea Guard Garrison Commanders and Storm Weavers (no per-1000 limit)
        SlotMapping[HighElvesTowModelType.SeaGuardGarrisonCommander] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.StormWeaver] = TowArmySlotType.Characters;
        // 0-1 Dragon Mage, High Elf Noble or High Elf Mage per 1,000 points
        SlotMapping[HighElvesTowModelType.DragonMage] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.Noble] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.Mage] = TowArmySlotType.Characters;

        // Core (at least 33%)
        // Lothern Sea Guard and Ship's Company (no per-1000 limit)
        SlotMapping[HighElvesTowModelType.LothernSeaGuard] = TowArmySlotType.Core;
        SlotMapping[HighElvesTowModelType.ShipsCompany] = TowArmySlotType.Core;
        // 0-1 unit of Shadow Warriors per 1,000 points
        SlotMapping[HighElvesTowModelType.ShadowWarriors] = TowArmySlotType.Core;

        // Special (up to 50%)
        // Lothern Skycutters (no per-1000 limit)
        SlotMapping[HighElvesTowModelType.LothernSkycutters] = TowArmySlotType.Special;
        // 0-2 Great Eagles per 1,000 points
        SlotMapping[HighElvesTowModelType.GreatEagle] = TowArmySlotType.Special;
        // 0-3 Eagle-Claw Bolt Throwers per 1,000 points
        SlotMapping[HighElvesTowModelType.EagleClawBoltThrower] = TowArmySlotType.Special;

        // Rare (up to 33%)
        // Ellyrian Reavers (no per-1000 limit)
        SlotMapping[HighElvesTowModelType.EllyrianReavers] = TowArmySlotType.Rare;
        // 0-1 Flamespyre or Frostheart Phoenix per 1,000 points
        SlotMapping[HighElvesTowModelType.FlamesphyrePhoenix] = TowArmySlotType.Rare;
        SlotMapping[HighElvesTowModelType.FrostheartPhoenix] = TowArmySlotType.Rare;
        // Merwyrms (no per-1000 limit)
        SlotMapping[HighElvesTowModelType.Merwyrm] = TowArmySlotType.Rare;

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
        // 0-1 Dragon Mage, Noble or Mage per 1,000 points (combined)
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfCharactersPerXPoints<HighElvesTowModelType>(
            army, new[] { HighElvesTowModelType.DragonMage, HighElvesTowModelType.Noble, HighElvesTowModelType.Mage }, 1));

        // === Unit Limits ===
        // 0-1 unit of Shadow Warriors per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, HighElvesTowModelType.ShadowWarriors, 1));
        // 0-2 Great Eagles per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, HighElvesTowModelType.GreatEagle, 2));
        // 0-3 Eagle-Claw Bolt Throwers per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, HighElvesTowModelType.EagleClawBoltThrower, 3));
        // 0-1 Flamespyre or Frostheart Phoenix per 1,000 points (combined)
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, new[] { HighElvesTowModelType.FlamesphyrePhoenix, HighElvesTowModelType.FrostheartPhoenix }, 1));

        // === Model Validation ===
        armyCompositionRules.Add(new TowArmyCompositionRuleAllowedModels(army, this));

        // === BSB Eligibility ===
        // A single High Elf Noble or Sea Guard Garrison Commander
        armyCompositionRules.Add(new TowArmyCompositionRuleBsbEligibility(
            army, new HashSet<Enum> { HighElvesTowModelType.Noble, HighElvesTowModelType.SeaGuardGarrisonCommander }));
    }
}
