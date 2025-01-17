using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class RepeaterCrossbowmanTowModel : TowModel
{
    private static int pointsCost = 11;

    public RepeaterCrossbowmanTowModel() : this(m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new RepeaterCrossbowmanChampionTowModel(), 5, 5, 5, 50, "Lordling");

        Armors.Add(new LightArmorTowArmor());
        AvailableArmors.Add((TowArmorType.Shield, 1));

        Weapons.Add(new RepeaterCrossbowTowWeapon());
        
        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new MartialProwess());

        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));
    }

    protected RepeaterCrossbowmanTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.RepeaterCrossbowmen, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {
    }
}

public class RepeaterCrossbowmanChampionTowModel : RepeaterCrossbowmanTowModel
{
    public RepeaterCrossbowmanChampionTowModel()
        : base(m: 5, ws: 4, bs: 5, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        
    }
}
