using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class RepeaterCrossbowmanTowModel : TowModel
{
    private static int pointsCost = 11;

    public RepeaterCrossbowmanTowModel(TowObject owner) : this(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new RepeaterCrossbowmanChampionTowModel(this), 5, 5, 5, 50, "Lordling");

    }

    protected RepeaterCrossbowmanTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, DarkElfTowModelType.RepeaterCrossbowmen, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new MartialProwess());

        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));

        // weapons
        AssignDefault(new RepeaterCrossbowTowWeapon(this));

        // armours
        AssignDefault(new LightArmourTowArmour(this));

        AvailableArmours.Add((TowArmourType.Shield, 1));
    }
}

public class RepeaterCrossbowmanChampionTowModel : RepeaterCrossbowmanTowModel
{
    public RepeaterCrossbowmanChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 4, bs: 5, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        
    }
}
