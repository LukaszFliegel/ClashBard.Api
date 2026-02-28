using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class LothernSeaGuardTowModel : TowModel
{
    private static int pointsCost = 11;

    public LothernSeaGuardTowModel(TowObject owner) : this(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new LothernSeaGuardChampionTowModel(this), 7, 5, 5, 25, "Sea Master");
    }

    protected LothernSeaGuardTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.LothernSeaGuard, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new NavalDiscipline());
        AssignSpecialRule(new ValourOfAges());

        // weapons - all are default equipment according to official rules
        AssignDefault(new ThrustingSpearTowWeapon(this));
        AssignDefault(new WarbowTowWeapon(this));

        // armours
        AssignDefault(new LightArmourTowArmour(this));
        
        // optional upgrades
        AvailableArmours.Add((TowArmourType.Shield, 1)); // Optional shield upgrade for +1 pt per model
        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1)); // Optional veteran upgrade for +1 pt per model
    }
}

public class LothernSeaGuardChampionTowModel : LothernSeaGuardTowModel
{
    public LothernSeaGuardChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 4, bs: 5, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
