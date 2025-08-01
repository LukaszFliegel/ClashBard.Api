using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class LothernSeaGuardTowModel : TowModel
{
    private static int pointsCost = 12;

    public LothernSeaGuardTowModel(TowObject owner) : this(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new LothernSeaGuardChampionTowModel(this), 5, 5, 5, 50, "Sea Master");
    }

    protected LothernSeaGuardTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.LothernSeaGuard, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 10)
    {                
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MartialProwess());

        // weapons
        AvailableWeapons.Add((TowWeaponType.Longbow, 0)); // Default weapon
        AvailableWeapons.Add((TowWeaponType.ThrustingSpear, 1));

        // armours
        AssignDefault(new LightArmourTowArmour(this));
        AssignDefault(new ShieldTowArmour(this));
    }
}

public class LothernSeaGuardChampionTowModel : LothernSeaGuardTowModel
{
    public LothernSeaGuardChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
