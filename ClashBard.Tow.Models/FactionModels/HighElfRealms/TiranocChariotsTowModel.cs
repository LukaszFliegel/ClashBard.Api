using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.FactionModels.HighElfRealms.Mounts;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class TiranocChariotsTowModel : TowModel
{
    private static int pointsCost = 85;

    public TiranocChariotsTowModel(TowObject owner) : this(owner, m: null, ws: 4, bs: 4, s: 5, t: 4, w: 4, i: 4, a: null, ld: 8)
    {
        // No command group for chariots
    }

    protected TiranocChariotsTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int? a, int? ld) 
        : base(owner, HighElvesTowModelType.TiranocChariots, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightChariot, new HighElvesTowFaction(), 50, 100, 1, 1)
    {                
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new ImpactHits1());
        AssignSpecialRule(new LargeTarget());

        // weapons - Crew equipped with longbows
        AvailableWeapons.Add((TowWeaponType.Longbow, 0)); // Default weapon for crew

        // armours
        AssignDefault(new LightArmourTowArmour(this));

        // Additional models - Chariot has 2 Elven Steeds pulling it
        // This would need a special chariot mount or additional models system
    }
}
