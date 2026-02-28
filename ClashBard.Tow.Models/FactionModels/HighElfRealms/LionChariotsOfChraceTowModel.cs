using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class LionChariotsOfChraceTowModel : TowModel
{
    private static int pointsCost = 125;

    public LionChariotsOfChraceTowModel(TowObject owner) : this(owner, m: null, ws: 5, bs: 4, s: 5, t: 4, w: 4, i: 5, a: null, ld: 8)
    {
        // No command group for chariots
    }

    protected LionChariotsOfChraceTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int? a, int? ld) 
        : base(owner, HighElvesTowModelType.LionChariotsOfChrace, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyChariot, new HighElvesTowFaction(), 50, 100, 1, 1)
    {                
        // special rules per JSON
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new ImpactHitsD6());
        AssignSpecialRule(new LionCloak());
        AssignSpecialRule(new Stubborn());
        AssignSpecialRule(new ValourOfAges());

        // weapons - White Lions crew with Chracian great blades (default per JSON)
        AssignDefault(new ChracianGreatBladeTowWeapon(this));
    }
}
