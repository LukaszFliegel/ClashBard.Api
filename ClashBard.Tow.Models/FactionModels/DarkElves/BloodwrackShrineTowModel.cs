using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class BloodwrackShrineTowModel : TowModel
{
    private static int pointsCost = 175;

    public BloodwrackShrineTowModel(TowObject owner) : this(owner, m: 2, ws: null, bs: 2, s: 5, t: 5, w: 5, i: null, a: null, ld: null)
    {
        
    }

    protected BloodwrackShrineTowModel(TowObject owner, int? m, int? ws, int? bs, int s, int t, int w, int? i, int? a, int? ld) 
        : base(owner, DarkElfTowModelType.BloodwrackShrine, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, 
            TowModelTroopType.HeavyChariot, new DarkElvesTowFaction(),
            60, 100, 1, 1, 4)
    {
        // special rules        
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new DraggedAlong());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Frenzy());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new ImpactHitsD6Plus1());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new MagicResistance1());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new PoisonedAttacks());
        AssignSpecialRule(new StonyStare());
        AssignSpecialRule(new Terror());

        // weapons

        // armours

        // crew
        Crew.Add(new ShrinekeeperTowModelAdditional(this));
        Crew.Add(new ShrinekeeperTowModelAdditional(this));

        Crew.Add(new BloodwrackMedusaTowModelAdditional(this));
    }
}
