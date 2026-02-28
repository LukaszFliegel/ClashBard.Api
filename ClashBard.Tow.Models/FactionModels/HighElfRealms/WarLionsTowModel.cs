using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class WarLionsTowModel : TowModel
{
    private static int pointsCost = 18;

    public WarLionsTowModel(TowObject owner)
        : base(owner, HighElvesTowModelType.WarLions, m: 8, ws: 5, bs: 0, s: 4, t: 4, w: 1, i: 4, a: 2, ld: 7, pointCost: pointsCost, TowModelTroopType.WarBeast, new HighElvesTowFaction(), 30, 60, minUnitSize: 2, maxUnitSize: 6)
    {
        // special rules
        AssignSpecialRule(new CleavingBlow());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new MoveThroughCover());
        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new Swiftstride());
        AssignSpecialRule(new Vanguard());
    }
}
