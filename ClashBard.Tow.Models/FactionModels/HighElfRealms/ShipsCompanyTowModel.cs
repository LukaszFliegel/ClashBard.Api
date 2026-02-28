using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class ShipsCompanyTowModel : TowModel
{
    private static int pointsCost = 9;

    public ShipsCompanyTowModel(TowObject owner) : this(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new ShipsCompanyMidshipmanTowModel(this), 5, 5, 5, championName: "Midshipman");
    }

    protected ShipsCompanyTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld)
        : base(owner, HighElvesTowModelType.ShipsCompany, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {
        // special rules
        AssignSpecialRule(new Detachment());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Evasive());
        AssignSpecialRule(new FireAndFlee());
        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new ValourOfAges());

        // default weapons - Hand weapons (base) + Warbows (default)
        AssignDefault(new WarbowTowWeapon(this));

        // weapon option - swap Warbows for Thrusting spears + Shields (0 pts)
        AvailableWeapons.Add((TowWeaponType.ThrustingSpear, 0));
        AvailableArmours.Add((TowArmourType.Shield, 0));

        // armour option
        AvailableArmours.Add((TowArmourType.LightArmour, 1));

        // special rule options
        AvailableSpecialRules.Add((TowSpecialRuleType.Skirmishers, 0));
        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));
    }
}

public class ShipsCompanyMidshipmanTowModel : ShipsCompanyTowModel
{
    public ShipsCompanyMidshipmanTowModel(TowObject owner)
        : base(owner, m: 5, ws: 4, bs: 5, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
    }
}
