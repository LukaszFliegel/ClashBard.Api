using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DoomfireWarlockTowModel : TowModel
{
    private static int pointsCost = 22;

    public DoomfireWarlockTowModel() : this(m: null, ws: 4, bs: 4, s: 4, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
        SetCommandGroup(new DoomfireWarlockChampionTowModel(), 6, null, null, null, "Master", 25);
    }

    protected DoomfireWarlockTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.DoomfireWarlocks, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightCavalry, new DarkElvesTowFaction(), 30, 60, minUnitSize: 5)
    {
        SpecialRules.Add(new CursedCoven());
        SpecialRules.Add(new DarkRunes());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new FastCavalry());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new OpenOrder());
        SpecialRules.Add(new PoisonedAttacks());
        SpecialRules.Add(new Swiftstride());

        Mount = new DarkSteedTowMount();
    }
}

public class DoomfireWarlockChampionTowModel : DoomfireWarlockTowModel
{
    public DoomfireWarlockChampionTowModel()
        : base(m: null, ws: 4, bs: 4, s: 4, t: 3, w: 1, i: 5, a: 2, ld: 8)
    {
        
    }
}
