using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class LionChariotsOfChraceTowModel : TowModel
{
    private static int pointsCost = 140;

    public LionChariotsOfChraceTowModel(TowObject owner) : this(owner, m: null, ws: 5, bs: 4, s: 5, t: 4, w: 4, i: 5, a: null, ld: 8)
    {
        // No command group for chariots
    }

    protected LionChariotsOfChraceTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int? a, int? ld) 
        : base(owner, HighElvesTowModelType.LionChariotsOfChrace, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyChariot, new HighElvesTowFaction(), 50, 100, 1, 1)
    {                
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new Stubborn());
        AssignSpecialRule(new ImpactHitsD3Plus1());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new Fear());

        // weapons - White Lions crew with great axes
        AvailableWeapons.Add((TowWeaponType.GreatWeapon, 0)); // Great axes for crew

        // armours
        AssignDefault(new LightArmourTowArmour(this));

        // Additional models - Chariot has 2 White Lions pulling it (special lion mounts)
        // This would need a special lion chariot mount or additional models system
    }
}
