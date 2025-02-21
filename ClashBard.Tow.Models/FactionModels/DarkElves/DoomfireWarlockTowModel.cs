using ClashBard.Tow.Models.FactionModels.DarkElves.Mounts;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DoomfireWarlockTowModel : TowModel
{
    private static int pointsCost = 22;

    public DoomfireWarlockTowModel(TowObject owner) : this(owner, m: null, ws: 4, bs: 4, s: 4, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
        SetCommandGroup(new DoomfireWarlockChampionTowModel(this), 6, null, null, null, "Master", 25);
    }

    protected DoomfireWarlockTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, DarkElvesTowModelType.DoomfireWarlocks, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightCavalry, new DarkElvesTowFaction(), 30, 60, minUnitSize: 5)
    {
        // special rules
        AssignSpecialRule(new CursedCoven());
        AssignSpecialRule(new DarkRunes());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new FastCavalry());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new PoisonedAttacks("(Doomfire Warlocks and Master only)"));
        AssignSpecialRule(new Swiftstride());

        // mounts
        AssignDefault(new DarkSteedTowMount(this));
    }
}

public class DoomfireWarlockChampionTowModel : DoomfireWarlockTowModel
{
    public DoomfireWarlockChampionTowModel(TowObject owner)
        : base(owner, m: null, ws: 4, bs: 4, s: 4, t: 3, w: 1, i: 5, a: 2, ld: 8)
    {
        
    }
}
