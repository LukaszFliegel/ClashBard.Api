using ClashBard.Tow.Models.FactionModels.DarkElves.Mounts;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ColdOneKnightTowModel : TowModel
{
    private static int pointsCost = 31;

    public ColdOneKnightTowModel(TowObject owner) : this(owner, m: null, ws: 5, bs: 4, s: 4, t: 4, w: 1, i: 5, a: 1, ld: 9)
    {
        SetCommandGroup(new ColdOneKnightChampionTowModel(this), 7, 7, 7, 50, "Dread Knight", 50);
    }

    protected ColdOneKnightTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, DarkElvesTowModelType.ColdOneKnights, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, 
            TowModelTroopType.HeavyCavalry, new DarkElvesTowFaction(), 
            30, 60, minUnitSize: 5)
    {
        // special rules        
        AssignSpecialRule(new ArmouredHide1());
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new Stupidity());
        AssignSpecialRule(new Swiftstride()); 
        
        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));

        // weapons
        AssignDefault(new LanceTowWeapon(this));

        // armours       
        AssignDefault(new HeavyArmourTowArmour(this));
        AssignDefault(new ShieldTowArmour(this));

        AvailableArmours.Add((TowArmourType.FullPlateArmour, 4));

        // mounts
        AssignDefault(new ColdOneTowMount(this));
    }
}

public class ColdOneKnightChampionTowModel : ColdOneKnightTowModel
{
    public ColdOneKnightChampionTowModel(TowObject owner)
        : base(owner, m: null, ws: 5, bs: 4, s: 4, t: 4, w: 1, i: 5, a: 2, ld: 9)
    {
        
    }
}
