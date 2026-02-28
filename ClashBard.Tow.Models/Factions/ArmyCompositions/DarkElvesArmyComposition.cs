using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;

namespace ClashBard.Tow.Models.Factions.ArmyCompositions;

/// <summary>
/// Grand Army composition for the Dark Elves.
/// Dark Elves currently have only one army composition.
/// </summary>
public class DarkElvesArmyComposition : TowArmyComposition
{
    public DarkElvesArmyComposition(TowArmy army)
    {
        // === Slot Mapping ===
        // Characters
        SlotMapping[DarkElvesTowModelType.DarkElfDreadlord] = TowArmySlotType.Characters;
        SlotMapping[DarkElvesTowModelType.DarkElfMaster] = TowArmySlotType.Characters;
        SlotMapping[DarkElvesTowModelType.SupremeSorceress] = TowArmySlotType.Characters;
        SlotMapping[DarkElvesTowModelType.Sorceress] = TowArmySlotType.Characters;
        SlotMapping[DarkElvesTowModelType.HighBeastmaster] = TowArmySlotType.Characters;
        SlotMapping[DarkElvesTowModelType.DeathHag] = TowArmySlotType.Characters;
        SlotMapping[DarkElvesTowModelType.KhainiteAssassin] = TowArmySlotType.Characters;

        // Core
        SlotMapping[DarkElvesTowModelType.DarkElfWarriors] = TowArmySlotType.Core;
        SlotMapping[DarkElvesTowModelType.RepeaterCrossbowmen] = TowArmySlotType.Core;
        SlotMapping[DarkElvesTowModelType.BlackArkCorsairs] = TowArmySlotType.Core;
        SlotMapping[DarkElvesTowModelType.DarkRiders] = TowArmySlotType.Core;

        // Special
        SlotMapping[DarkElvesTowModelType.BlackGuardOfNaggarond] = TowArmySlotType.Special;
        SlotMapping[DarkElvesTowModelType.HarGanethExecutioners] = TowArmySlotType.Special;
        SlotMapping[DarkElvesTowModelType.DarkElfShades] = TowArmySlotType.Special;
        SlotMapping[DarkElvesTowModelType.WitchElves] = TowArmySlotType.Special;
        SlotMapping[DarkElvesTowModelType.Harpies] = TowArmySlotType.Special;
        SlotMapping[DarkElvesTowModelType.ColdOneKnights] = TowArmySlotType.Special;
        SlotMapping[DarkElvesTowModelType.ColdOneChariots] = TowArmySlotType.Special;
        SlotMapping[DarkElvesTowModelType.ScourgerunnerChariots] = TowArmySlotType.Special;

        // Rare
        SlotMapping[DarkElvesTowModelType.SistersOfSlaughter] = TowArmySlotType.Rare;
        SlotMapping[DarkElvesTowModelType.DoomfireWarlocks] = TowArmySlotType.Rare;
        SlotMapping[DarkElvesTowModelType.BloodwrackShrine] = TowArmySlotType.Rare;
        SlotMapping[DarkElvesTowModelType.WarHydra] = TowArmySlotType.Rare;
        SlotMapping[DarkElvesTowModelType.BloodwrackMedusa] = TowArmySlotType.Rare;
        SlotMapping[DarkElvesTowModelType.Kharibdyss] = TowArmySlotType.Rare;
        SlotMapping[DarkElvesTowModelType.ReaperBoltThrower] = TowArmySlotType.Rare;

        // === Percentage Rules ===
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Characters, maxPercent: 50));
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Core, minPercent: 25));
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Special, maxPercent: 50));
        armyCompositionRules.Add(new TowArmyCompositionRuleSlotPercentage(army, this,
            TowArmySlotType.Rare, maxPercent: 25));

        // === Character Limits ===
        // 0-1 Dark Elf Dreadlord or Supreme Sorceress per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfCharactersPerXPoints<DarkElvesTowModelType>(
            army, new[] { DarkElvesTowModelType.DarkElfDreadlord, DarkElvesTowModelType.SupremeSorceress }, 1));

        // === Unit Limits ===
        // 0-1 Cold One Knights per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<DarkElvesTowModelType>(
            army, DarkElvesTowModelType.ColdOneKnights, 1));

        // 0-2 Scourgerunner Chariots or Cold One Chariots per 1,000 points (combined)
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<DarkElvesTowModelType>(
            army, new[] { DarkElvesTowModelType.ScourgerunnerChariots, DarkElvesTowModelType.ColdOneChariots }, 2));

        // 0-1 unit of Doomfire Warlocks per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<DarkElvesTowModelType>(
            army, DarkElvesTowModelType.DoomfireWarlocks, 1));

        // 0-2 Reaper Bolt Throwers per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<DarkElvesTowModelType>(
            army, DarkElvesTowModelType.ReaperBoltThrower, 2));

        // === Mount Limits ===
        // 0-1 Cauldron of Blood per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<DarkElvesTowModelMountType>(
            army, DarkElvesTowModelMountType.CauldronOfBlood, 1));

        // === Model Validation ===
        armyCompositionRules.Add(new TowArmyCompositionRuleAllowedModels(army, this));

        // === BSB Eligibility ===
        // A single Dark Elf Master may be upgraded to be your Battle Standard Bearer
        armyCompositionRules.Add(new TowArmyCompositionRuleBsbEligibility(
            army, new HashSet<Enum> { DarkElvesTowModelType.DarkElfMaster }));
    }
}
