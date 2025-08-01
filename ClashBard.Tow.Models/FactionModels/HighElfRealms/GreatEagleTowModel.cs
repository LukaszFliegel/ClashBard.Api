using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class GreatEagleTowModel : TowModel
{
    private static int pointsCost = 50;

    public GreatEagleTowModel(TowObject owner) : base(owner, HighElvesTowModelType.GreatEagle, 
        m: 2, ws: 5, bs: 0, s: 4, t: 4, w: 3, i: 4, a: 2, ld: 8, pointCost: pointsCost, 
        TowModelTroopType.MonstrousCreature, new HighElvesTowFaction(), 40, 40, 1, 1)
    {                
        // special rules
        AssignSpecialRule(new Fly9());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new Terror());
        AssignSpecialRule(new ValourOfAges());

        // Natural weapons only (claws and beak)
        // No armor (natural creature)
    }
}
