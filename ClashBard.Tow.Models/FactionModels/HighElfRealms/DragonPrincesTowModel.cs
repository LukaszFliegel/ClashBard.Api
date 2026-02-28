using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.FactionModels.HighElfRealms.Mounts;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class DragonPrincesTowModel : TowModel
{
    private static int pointsCost = 37;

    public DragonPrincesTowModel(TowObject owner) : this(owner, m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 5, a: 2, ld: 9)
    {
        SetCommandGroup(new DragonPrincesDrakemasterTowModel(this), 7, 7, 7, 50, "Drakemaster", 50);
    }

    protected DragonPrincesTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.DragonPrinces, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyCavalry, new HighElvesTowFaction(), 30, 60, minUnitSize: 5)
    {                
        // special rules per JSON & website
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new CounterCharge());
        AssignSpecialRule(new DragonArmour());
        AssignSpecialRule(new Drilled());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new Impetuous());
        AssignSpecialRule(new IthilmarBarding());
        AssignSpecialRule(new IthilmarWeapons());
        AssignSpecialRule(new SonsOfCaledor());
        AssignSpecialRule(new Swiftstride());
        AssignSpecialRule(new ValourOfAges());

        // weapons - Hand weapons (base class) + Lances (default)
        AssignDefault(new LanceTowWeapon(this));

        // armours - Full plate armour + Shields (default)
        AssignDefault(new FullPlateArmourTowArmour(this));
        AssignDefault(new ShieldTowArmour(this));

        // mount - Barded Elven Steed (default, barding included via IthilmarBarding rule)
        AssignDefault(new BardedElvenSteedTowMount(this));
    }
}

public class DragonPrincesDrakemasterTowModel : DragonPrincesTowModel
{
    public DragonPrincesDrakemasterTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 5, a: 3, ld: 9)
    {
    }
}
