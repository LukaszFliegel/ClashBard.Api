using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DarkRiderTowModel : TowModel
{
    private static int pointsCost = 16;

    public DarkRiderTowModel(TowObject owner) : this(owner, m: null, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new DarkRiderChampionTowModel(this), 6, 6, 6, null, "Herald");

        
    }

    protected DarkRiderTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, DarkElfTowModelType.DarkRiders, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightCavalry, new DarkElvesTowFaction(), 30, 60, minUnitSize: 5)
    {
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new FastCavalry());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new Skirmishers());
        AssignSpecialRule(new Swiftstride());

        AvailableSpecialRules.Add((TowSpecialRuleType.FireAndFlee, 1));
        AvailableSpecialRules.Add((TowSpecialRuleType.Scouts, 1));

        // weapons
        AssignDefault(new CavalrySpearTowWeapon(this));

        AvailableWeapons.Add((TowWeaponType.RepeaterCrossbow, 2));

        // armorus
        AssignDefault(new LightArmourTowArmour(this));

        AvailableArmours.Add((TowArmourType.Shield, 1));

        // mounts
        AssignDefault(new DarkSteedTowMount(this));
    }
}

public class DarkRiderChampionTowModel : DarkRiderTowModel
{
    public DarkRiderChampionTowModel(TowObject owner)
        : base(owner, m: null, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
