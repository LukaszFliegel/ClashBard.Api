using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Factions.ArmyCompositions;

public class HighElvesArmyComposition : TowArmyComposition
{
    public HighElvesArmyComposition(TowArmy army)
    {
        // 0-1 Prince or Archmage per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(army, HighElvesTowModelType.Prince, 1));
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(army, HighElvesTowModelType.Archmage, 1));

        // 0-1 Great Eagle per 1,000 points
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<HighElvesTowModelType>(army, HighElvesTowModelType.GreatEagle, 1));

        // 0-1 Dragon mount per 1,000 points (taken as mounts)
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<HighElvesTowModelMountType>(army, HighElvesTowModelMountType.StarDragon, 1));
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<HighElvesTowModelMountType>(army, HighElvesTowModelMountType.SunDragon, 1));
        armyCompositionRules.Add(new TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<HighElvesTowModelMountType>(army, HighElvesTowModelMountType.MoonDragon, 1));
    }
}
