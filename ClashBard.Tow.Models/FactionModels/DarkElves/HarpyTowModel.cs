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
        SpecialRules.Add(new Fly10());
        SpecialRules.Add(new MoveThroughCover());
        SpecialRules.Add(new Scouts());
        SpecialRules.Add(new Skirmishers());
        SpecialRules.Add(new Swiftstride());
    }
}

//public class HarpyChampionTowModel : HarpyTowModel
//{
//    public HarpyChampionTowModel()
//        : base(m: 5, ws: 3, bs: 0, s: 3, t: 3, w: 1, i: 5, a: 2, ld: 6)
//    {
        
//    }
//}
