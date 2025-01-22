using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DarkRiderTowModel : TowModel
{
    private static int pointsCost = 16;

    public DarkRiderTowModel() : this(m: null, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new DarkRiderChampionTowModel(), 6, 6, 6, null, "Herald");

        
    }

    protected DarkRiderTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.DarkRiders, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightCavalry, new DarkElvesTowFaction(), 30, 60, minUnitSize: 5)
    {
        Armours.Add(new LightArmourTowArmour());

        AvailableArmours.Add((TowArmourType.Shield, 1));

        Weapons.Add(new CavalrySpearTowWeapon());

        AvailableWeapons.Add((TowWeaponType.RepeaterCrossbow, 2));

        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new FastCavalry());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new OpenOrder());
        SpecialRules.Add(new Skirmishers());
        SpecialRules.Add(new Swiftstride());

        AvailableSpecialRules.Add((TowSpecialRuleType.FireAndFlee, 1));
        AvailableSpecialRules.Add((TowSpecialRuleType.Scouts, 1));

        Mount = new DarkSteedTowMount();
    }
}

public class DarkRiderChampionTowModel : DarkRiderTowModel
{
    public DarkRiderChampionTowModel()
        : base(m: null, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
