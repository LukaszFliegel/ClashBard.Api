using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class WhiteLionsOfChraceTowModel : TowModel
{
    private static int pointsCost = 14;

    public WhiteLionsOfChraceTowModel(TowObject owner) : this(owner, m: 5, ws: 5, bs: 4, s: 4, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new WhiteLionsOfChraceChampionTowModel(this), 5, 5, 5, 25, "Guardian");
    }

    protected WhiteLionsOfChraceTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.WhiteLionsOfChrace, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // special rules per JSON
        AssignSpecialRule(new ChracianWarriors());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new FuriousCharge());
        AssignSpecialRule(new KingsGuard());
        AssignSpecialRule(new LionCloak());
        AssignSpecialRule(new MoveThroughCover());
        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new Stubborn());
        AssignSpecialRule(new ValourOfAges());

        // options
        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));

        // weapons        
        AssignDefault(new ChracianGreatBladeTowWeapon(this));

        // armours
        AssignDefault(new HeavyArmourTowArmour(this));
    }
}

public class WhiteLionsOfChraceChampionTowModel : WhiteLionsOfChraceTowModel
{
    public WhiteLionsOfChraceChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 4, s: 4, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
