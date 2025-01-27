using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class HarpyTowModel : TowModel
{
    private static int pointsCost = 11;

    public HarpyTowModel(TowObject owner) : this(owner, m: 5, ws: 3, bs: 0, s: 3, t: 3, w: 1, i: 5, a: 2, ld: 6)
    {
        SetCommandGroup(null, null, null, null);
    }

    protected HarpyTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, DarkElfTowModelType.Harpies, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 5)
    {
        // special rules
        AssignSpecialRule(new Fly10());
        AssignSpecialRule(new MoveThroughCover());
        AssignSpecialRule(new Scouts());
        AssignSpecialRule(new Skirmishers());
        AssignSpecialRule(new Swiftstride());
    }
}