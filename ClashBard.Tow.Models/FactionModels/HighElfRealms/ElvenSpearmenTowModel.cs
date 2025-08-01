using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class ElvenSpearmenTowModel : TowModel
{
    private static int pointsCost = 9;

    public ElvenSpearmenTowModel(TowObject owner) : this(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new SpearmenChampionTowModel(this), 5, 5, 5, 50, "Sentinel");
    }

    protected ElvenSpearmenTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.Spearmen, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new RegimentalUnit());
        AssignSpecialRule(new ValourOfAges());

        // weapons
        AssignDefault(new ThrustingSpearTowWeapon(this));

        // armours
        AssignDefault(new LightArmourTowArmour(this));
        AssignDefault(new ShieldTowArmour(this));
    }
}

public class SpearmenChampionTowModel : ElvenSpearmenTowModel
{
    public SpearmenChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
