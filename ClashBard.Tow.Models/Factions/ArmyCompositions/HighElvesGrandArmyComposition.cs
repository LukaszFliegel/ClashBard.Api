using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;

namespace ClashBard.Tow.Models.Factions.ArmyCompositions;

/// <summary>
/// Grand Army composition for the High Elf Realms.
/// This is the default (broadest) army composition for High Elves.
/// Other compositions (Sea Guard Garrison, Chracian Warhost, etc.)
/// would be separate subclasses with different SlotMapping and rules.
/// </summary>
public class HighElvesGrandArmyComposition : TowArmyComposition
{
    public HighElvesGrandArmyComposition(TowArmy army)
    {
        // === Slot Mapping ===
        // Characters
        SlotMapping[HighElvesTowModelType.EltharionTheGrim] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.Prince] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.Archmage] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.Noble] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.Mage] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.LoremasterOfHoeth] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.IshayaVess] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.KorhilLionmane] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.ChracianChieftain] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.DragonMage] = TowArmySlotType.Characters;
        SlotMapping[HighElvesTowModelType.HandmaidenOfTheEverqueen] = TowArmySlotType.Characters;

        // Core
        SlotMapping[HighElvesTowModelType.Spearmen] = TowArmySlotType.Core;
        SlotMapping[HighElvesTowModelType.Archers] = TowArmySlotType.Core;
        SlotMapping[HighElvesTowModelType.LothernSeaGuard] = TowArmySlotType.Core;
        SlotMapping[HighElvesTowModelType.EllyrianReavers] = TowArmySlotType.Core;
        SlotMapping[HighElvesTowModelType.SilverHelms] = TowArmySlotType.Core;

        // Special
        SlotMapping[HighElvesTowModelType.WhiteLionsOfChrace] = TowArmySlotType.Special;
        SlotMapping[HighElvesTowModelType.SwordMastersOfHoeth] = TowArmySlotType.Special;
        SlotMapping[HighElvesTowModelType.PhoenixGuard] = TowArmySlotType.Special;
        SlotMapping[HighElvesTowModelType.ShadowWarriors] = TowArmySlotType.Special;
        SlotMapping[HighElvesTowModelType.TiranocChariots] = TowArmySlotType.Special;
        SlotMapping[HighElvesTowModelType.ChracianWoodsmen] = TowArmySlotType.Special;
        SlotMapping[HighElvesTowModelType.DragonPrinces] = TowArmySlotType.Special;
        // Lothern Skycutter: 0-1 Special if General has Sea Guard Elven Honour
        SlotMapping[HighElvesTowModelType.LothernSkycutters] = TowArmySlotType.Special;

        // Rare
        SlotMapping[HighElvesTowModelType.LionChariotsOfChrace] = TowArmySlotType.Rare;
        SlotMapping[HighElvesTowModelType.LionGuard] = TowArmySlotType.Rare;
        SlotMapping[HighElvesTowModelType.FlamesphyrePhoenix] = TowArmySlotType.Rare;
        SlotMapping[HighElvesTowModelType.FrostheartPhoenix] = TowArmySlotType.Rare;
        SlotMapping[HighElvesTowModelType.GreatEagle] = TowArmySlotType.Rare;
        SlotMapping[HighElvesTowModelType.EagleClawBoltThrower] = TowArmySlotType.Rare;
        SlotMapping[HighElvesTowModelType.SistersOfAvelorn] = TowArmySlotType.Rare;
        // War Lions: 0-1 Rare if army includes one or more White Lions of Chrace
        SlotMapping[HighElvesTowModelType.WarLions] = TowArmySlotType.Rare;
        // Merwyrm: 0-1 Rare if army includes one or more Lothern Sea Guard
        SlotMapping[HighElvesTowModelType.Merwyrm] = TowArmySlotType.Rare;

        // === Percentage Rules ===
        // Characters: up to 50%
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Characters, maxPercent: 50));
        // Core: at least 25%
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Core, minPercent: 25));
        // Special: up to 50%
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Special, maxPercent: 50));
        // Rare: up to 25%
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Rare, maxPercent: 25));

        // === Character Limits ===
        // 0-1 Prince or Archmage per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfCharactersPerXPoints<HighElvesTowModelType>(
            army, new[] { HighElvesTowModelType.Prince, HighElvesTowModelType.Archmage }, 1));
        // 0-1 Dragon Mage or Handmaiden of the Everqueen per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfCharactersPerXPoints<HighElvesTowModelType>(
            army, new[] { HighElvesTowModelType.DragonMage, HighElvesTowModelType.HandmaidenOfTheEverqueen }, 1));

        // === Unit Limits ===
        // 0-1 Flamespyre or Frostheart Phoenix (not counting character mounts) per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, new[] { HighElvesTowModelType.FlamesphyrePhoenix, HighElvesTowModelType.FrostheartPhoenix }, 1));
        // 0-2 Great Eagles per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, HighElvesTowModelType.GreatEagle, 2));
        // 0-2 Eagle Claw Bolt Throwers per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, HighElvesTowModelType.EagleClawBoltThrower, 2));
        // 0-1 Dragon Princes of Caledor per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(
            army, HighElvesTowModelType.DragonPrinces, 1));
        // 0-1 Lothern Skycutter (conditional on General having Sea Guard Elven Honour)
        armyCompositionRules.Add(new TowArmyCompositionRuleMaxNumberOfUnits<HighElvesTowModelType>(
            army, HighElvesTowModelType.LothernSkycutters, 1));
        // 0-1 War Lions (conditional on army including White Lions of Chrace)
        armyCompositionRules.Add(new TowArmyCompositionRuleMaxNumberOfUnits<HighElvesTowModelType>(
            army, HighElvesTowModelType.WarLions, 1));
        // 0-1 Merwyrm (conditional on army including Lothern Sea Guard)
        armyCompositionRules.Add(new TowArmyCompositionRuleMaxNumberOfUnits<HighElvesTowModelType>(
            army, HighElvesTowModelType.Merwyrm, 1));

        // === Mount Limits ===
        // 0-1 Dragon mounts per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<HighElvesTowModelMountType>(
            army, HighElvesTowModelMountType.StarDragon, 1));
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<HighElvesTowModelMountType>(
            army, HighElvesTowModelMountType.SunDragon, 1));
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<HighElvesTowModelMountType>(
            army, HighElvesTowModelMountType.MoonDragon, 1));

        // === Model Validation ===
        armyCompositionRules.Add(new TowArmyCompositionRuleAllowedModels(army, this));

        // === BSB Eligibility ===
        // A single High Elf Noble may be upgraded to be your Battle Standard Bearer
        armyCompositionRules.Add(new TowArmyCompositionRuleBsbEligibility(
            army, new HashSet<Enum> { HighElvesTowModelType.Noble }));
    }
}
