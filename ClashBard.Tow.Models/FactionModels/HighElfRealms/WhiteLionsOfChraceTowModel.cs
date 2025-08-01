using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class WhiteLionsOfChraceTowModel : TowModel
{
    private static int pointsCost = 14;

    public WhiteLionsOfChraceTowModel(TowObject owner) : this(owner, m: 5, ws: 5, bs: 4, s: 4, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new WhiteLionsOfChraceChampionTowModel(this), 5, 5, 5, 50, "Guardian");
    }

    protected WhiteLionsOfChraceTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.WhiteLionsOfChrace, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 10)
    {                
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new Stubborn());

        // weapons        
        AvailableWeapons.Add((TowWeaponType.GreatWeapon, 0)); // White Lions carry great axes

        // armours
        AssignDefault(new LightArmourTowArmour(this));
    }
}

public class WhiteLionsOfChraceChampionTowModel : WhiteLionsOfChraceTowModel
{
    public WhiteLionsOfChraceChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 4, s: 4, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
