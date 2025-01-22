using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DarkElfWarriorTowModel : TowModel
{
    private static int pointsCost = 8;

    public DarkElfWarriorTowModel() : this(m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new DarkElfWarriorChampionTowModel(), 5, 5, 5, 50, "Lordling");
    }

    protected DarkElfWarriorTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.DarkElfWarriors, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {        
        Armours.Add(new LightArmourTowArmour());
        Armours.Add(new ShieldTowArmour());

        AvailableWeapons.Add((TowWeaponType.ThrustingSpear, 1));

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new MartialProwess());

        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));
    }
}

public class DarkElfWarriorChampionTowModel : DarkElfWarriorTowModel
{
    public DarkElfWarriorChampionTowModel()
        : base(m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
