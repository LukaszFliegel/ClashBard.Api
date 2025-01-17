using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class HarGanethExecutionerTowModel : TowModel
{
    private static int pointsCost = 15;

    public HarGanethExecutionerTowModel() : this(m: 5, ws: 5, bs: 4, s: 4, t: 3, w: 1, i: 5, a: 1, ld: 9)
    {
        SetCommandGroup(new HarGanethExecutionerChampionTowModel(), 6, 6, 6, 50, "Draich Master", 25);

        Armors.Add(new HeavyArmorTowArmor());

        Weapons.Add(new HarGanethGreatswordTowWeapon());

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new Murderous());
        SpecialRules.Add(new Veteran());

        AvailableSpecialRules.Add((TowSpecialRuleType.Drilled, 2));
    }

    protected HarGanethExecutionerTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.HarGanethExecutioners, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {
    }
}

public class HarGanethExecutionerChampionTowModel : HarGanethExecutionerTowModel
{
    public HarGanethExecutionerChampionTowModel()
        : base(m: 5, ws: 5, bs: 4, s: 4, t: 3, w: 1, i: 5, a: 2, ld: 9)
    {
        
    }
}
