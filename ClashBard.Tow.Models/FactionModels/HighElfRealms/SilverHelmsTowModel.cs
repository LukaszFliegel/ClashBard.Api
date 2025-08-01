using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.FactionModels.HighElfRealms.Mounts;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class SilverHelmsTowModel : TowModel
{
    private static int pointsCost = 23;

    public SilverHelmsTowModel(TowObject owner) : this(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new SilverHelmsChampionTowModel(this), 6, 6, 6, 25, "High Helm");
    }

    protected SilverHelmsTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.SilverHelms, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyCavalry, new HighElvesTowFaction(), 30, 60, minUnitSize: 5)
    {                
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new IthilmarBarding());
        AssignSpecialRule(new Swiftstride());
        AssignSpecialRule(new ValourOfAges());

        // weapons        
        AvailableWeapons.Add((TowWeaponType.Lance, 3));
        // Default: Hand weapons, already included in base class

        // armours
        AssignDefault(new HeavyArmourTowArmour(this));
        AvailableArmours.Add((TowArmourType.Shield, 1));

        // mount
        AssignDefault(new BardedElvenSteedTowMount(this));
    }
}

public class SilverHelmsChampionTowModel : SilverHelmsTowModel
{
    public SilverHelmsChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
