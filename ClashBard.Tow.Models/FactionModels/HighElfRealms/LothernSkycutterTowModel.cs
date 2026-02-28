using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.Models.Weapons.FactionWeapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class LothernSkycutterTowModel : TowModel
{
    private static int pointsCost = 90;

    public LothernSkycutterTowModel(TowObject owner)
        : base(owner, HighElvesTowModelType.LothernSkycutters, m: null, ws: 4, bs: 4, s: 5, t: 4, w: 4, i: 4, a: 0, ld: 8, pointCost: pointsCost, TowModelTroopType.HeavyChariot, new HighElvesTowFaction(), 60, 100, minUnitSize: 1, maxUnitSize: 1)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new Fly10());
        AssignSpecialRule(new ImpactHitsD3Plus1());
        AssignSpecialRule(new Swiftstride());
        AssignSpecialRule(new ValourOfAges());

        // crew weapons - Cavalry spears + Shortbows
        Assign(new CavalrySpearTowWeapon(this));
        Assign(new ShortbowTowWeapon(this));

        // optional upgrade - Eagle-Eye Bolt Thrower
        AvailableWeapons.Add((TowWeaponType.EagleEyeBoltThrower, 25));
    }
}
