using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class SisterOfSlaughterTowModel : TowModel
{
    private static int pointsCost = 17;

    public SisterOfSlaughterTowModel() : this(m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 6, a: 2, ld: 9)
    {
        SetCommandGroup(new SisterOfSlaughterChampionTowModel(), 7, 7, 7, 50, "Hag");

        Weapons.Add(new LashAndBucklerTowWeapon());

        SpecialRules.Add(new DanceOfDeath());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new Impetuous());
        SpecialRules.Add(new Loner());
        SpecialRules.Add(new Murderous());
        SpecialRules.Add(new OpenOrder());
    }

    protected SisterOfSlaughterTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.SistersOfSlaughter, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {
    }
}

public class SisterOfSlaughterChampionTowModel : SisterOfSlaughterTowModel
{
    public SisterOfSlaughterChampionTowModel()
        : base(m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 6, a: 3, ld: 9)
    {
        
    }
}
