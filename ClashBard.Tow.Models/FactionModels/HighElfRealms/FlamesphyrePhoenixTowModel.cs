using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class FlamesphyrePhoenixTowModel : TowModel
{
    private static int pointsCost = 170;

    public FlamesphyrePhoenixTowModel(TowObject owner) : this(owner, m: 20, ws: 5, bs: 0, s: 5, t: 5, w: 5, i: 4, a: 2, ld: 8)
    {
        // No command group for monsters
    }

    protected FlamesphyrePhoenixTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.FlamesphyrePhoenix, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.MonstrousCreature, new HighElvesTowFaction(), 50, 50, 1, 1)
    {                
        // special rules per JSON
        AssignSpecialRule(new BlessingsOfAsuryan());
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new FlamingAttacks());
        AssignSpecialRule(new Fly10());
        AssignSpecialRule(new FromTheAshes());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new StompAttacks2());
        AssignSpecialRule(new Swiftstride());
        AssignSpecialRule(new WakeOfFire());

        // armours - Heavy armour per JSON
        AssignDefault(new HeavyArmourTowArmour(this));
    }
}
