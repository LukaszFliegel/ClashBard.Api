using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class HarGanethExecutionerTowModel : TowModel
{
    private static int pointsCost = 15;

    public HarGanethExecutionerTowModel(TowObject owner) : this(owner, m: 5, ws: 5, bs: 5, s: 4, t: 4, w: 1, i: 5, a: 1, ld: 9)
    {
        SetCommandGroup(new HarGanethExecutionerChampionTowModel(this), 6, 6, 6, 50, "Draich Master", 25);

    }

    protected HarGanethExecutionerTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, DarkElvesTowModelType.HarGanethExecutioners, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new Veteran());

        AvailableSpecialRules.Add((TowSpecialRuleType.Drilled, 2));

        // wepons
        AssignDefault(new HarGanethGreatswordTowWeapon(this));

        // armours
        AssignDefault(new HeavyArmourTowArmour(this));
    }
}

public class HarGanethExecutionerChampionTowModel : HarGanethExecutionerTowModel
{
    public HarGanethExecutionerChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 4, s: 4, t: 3, w: 1, i: 5, a: 2, ld: 9)
    {
        
    }
}
