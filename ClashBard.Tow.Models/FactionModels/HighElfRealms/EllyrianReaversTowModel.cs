using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.FactionModels.HighElfRealms.Mounts;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class EllyrianReaversTowModel : TowModel
{
    private static int pointsCost = 16;

    public EllyrianReaversTowModel(TowObject owner) : this(owner, m: 4, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new EllyrianReaversChampionTowModel(this), 8, 6, 6, 25, "Harbinger");
    }

    protected EllyrianReaversTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.EllyrianReavers, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightCavalry, new HighElvesTowFaction(), 30, 60, minUnitSize: 5)
    {                
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new FastCavalry());
        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new Swiftstride());

        // weapons        
        AvailableWeapons.Add((TowWeaponType.CavalrySpear, 0)); // Default weapon
        AvailableWeapons.Add((TowWeaponType.Shortbow, 1)); // Optional shortbows

        // armours
        AssignDefault(new LightArmourTowArmour(this));

        // mount
        AssignDefault(new ElvenSteedTowMount(this));
    }
}

public class EllyrianReaversChampionTowModel : EllyrianReaversTowModel
{
    public EllyrianReaversChampionTowModel(TowObject owner)
        : base(owner, m: 4, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
