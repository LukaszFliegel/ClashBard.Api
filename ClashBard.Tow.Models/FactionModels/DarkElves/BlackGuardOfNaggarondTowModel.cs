using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class BlackGuardOfNaggarondTowModel : TowModel
{
    private static int pointsCost = 15;

    public BlackGuardOfNaggarondTowModel() : this(m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 9)
    {
        SetCommandGroup(new BlackGuardOfNaggarondChampionTowModel(), 7, 7, 7, 100, "Tower Master", 50);

        Armors.Add(new FullPlateArmourTowArmor());

        Weapons.Add(new DreadHalberdTowWeapon());

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new EternalHatred());        
        SpecialRules.Add(new ImmuneToPsychology());
        SpecialRules.Add(new MartialProwess());
        SpecialRules.Add(new Stubborn());

        AvailableSpecialRules.Add((TowSpecialRuleType.Drilled, 1));
    }

    protected BlackGuardOfNaggarondTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.BlackGuardOfNaggarond, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {
    }
}

public class BlackGuardOfNaggarondChampionTowModel : BlackGuardOfNaggarondTowModel
{
    public BlackGuardOfNaggarondChampionTowModel()
        : base(m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 5, a: 2, ld: 9)
    {
        
    }
}
