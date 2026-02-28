using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class LionGuardTowModel : TowModel
{
    private static int pointsCost = 18;

    public LionGuardTowModel(TowObject owner) : this(owner, m: 5, ws: 6, bs: 4, s: 4, t: 3, w: 1, i: 5, a: 1, ld: 9)
    {
        SetCommandGroup(new LionGuardCaptainTowModel(this), 7, 7, 7, 50, "Lion Guard Captain");
    }

    protected LionGuardTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.LionGuard, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // special rules
        AssignSpecialRule(new ChampionsOfChrace());
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new FuriousCharge());
        AssignSpecialRule(new LionCloak());
        AssignSpecialRule(new Stubborn());
        AssignSpecialRule(new Veteran());

        // weapons
        AssignDefault(new ChracianGreatBladeTowWeapon(this));

        // armours
        AssignDefault(new HeavyArmourTowArmour(this));
    }
}

public class LionGuardCaptainTowModel : LionGuardTowModel
{
    public LionGuardCaptainTowModel(TowObject owner)
        : base(owner, m: 5, ws: 6, bs: 4, s: 4, t: 3, w: 1, i: 5, a: 2, ld: 9)
    {
        
    }
}
