using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DarkElfWarriorTowModel : TowModel
{
    private static int pointsCost = 8;

    public DarkElfWarriorTowModel(TowObject owner) : this(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new DarkElfWarriorChampionTowModel(this), 5, 5, 5, 50, "Lordling");
    }

    protected DarkElfWarriorTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, DarkElvesTowModelType.DarkElfWarriors, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {                
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new MartialProwess());

        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));

        // weapons        
        AvailableWeapons.Add((TowWeaponType.ThrustingSpear, 1));

        // armours
        AssignDefault(new LightArmourTowArmour(this));
        AssignDefault(new ShieldTowArmour(this));
    }
}

public class DarkElfWarriorChampionTowModel : DarkElfWarriorTowModel
{
    public DarkElfWarriorChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
