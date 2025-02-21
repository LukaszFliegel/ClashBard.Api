using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Factions.ArmyCompositions;
public class DarkElvesArmyComposition : TowArmyComposition
{
    public DarkElvesArmyComposition(TowArmy army)
    {
        // 0-1 Dark Elf Dreadlord or Supreme Sorceress per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<DarkElvesTowModelType>(army, DarkElvesTowModelType.DarkElfDreadlord, 1));
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<DarkElvesTowModelType>(army, DarkElvesTowModelType.SupremeSorceress, 1));

        // 0-1 Cauldron of Blood per 1,000 points (taken as a mount for a Death Hag)
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<DarkElvesTowModelMountType>(army, DarkElvesTowModelMountType.CauldronOfBlood, 1));

        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<DarkElvesTowModelType>(army, DarkElvesTowModelType.ColdOneKnights, 1));
    }
}
