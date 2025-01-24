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
        : base(owner, DarkElfTowModelType.BloodwrackShrine, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyChariot, new DarkElvesTowFaction(), 60, 100, 1, 1, 4)
    {
        Crew.Add(new ShrinekeeperTowModelAdditional(this));
        Crew.Add(new ShrinekeeperTowModelAdditional(this));

        Crew.Add(new BloodwrackMedusaTowModelAdditional(this));

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new DraggedAlong());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new Frenzy());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new ImpactHitsD6Plus1());
        SpecialRules.Add(new LargeTarget());
        SpecialRules.Add(new MagicResistance1());
        SpecialRules.Add(new Murderous());
        SpecialRules.Add(new PoisonedAttacks());
        SpecialRules.Add(new StonyStare());
        SpecialRules.Add(new Terror());
    }
}
