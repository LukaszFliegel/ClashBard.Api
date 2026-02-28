using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.FactionModels.HighElfRealms.Mounts;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class TiranocChariotsTowModel : TowModel
{
    private static int pointsCost = 75;

    public TiranocChariotsTowModel(TowObject owner) : this(owner, m: null, ws: 4, bs: 4, s: 5, t: 4, w: 4, i: 4, a: null, ld: 8)
    {
        // No command group for chariots
    }

    protected TiranocChariotsTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int? a, int? ld) 
        : base(owner, HighElvesTowModelType.TiranocChariots, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightChariot, new HighElvesTowFaction(), 50, 100, 1, 4)
    {                
        // special rules per JSON
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ImpactHitsD6());
        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new QuickShot());
        AssignSpecialRule(new Swiftstride());
        AssignSpecialRule(new ValourOfAges());

        // weapons - Crew equipped with cavalry spears and longbows (default per JSON)
        AssignDefault(new CavalrySpearTowWeapon(this));
        AssignDefault(new LongbowTowWeapon(this));
    }
}
