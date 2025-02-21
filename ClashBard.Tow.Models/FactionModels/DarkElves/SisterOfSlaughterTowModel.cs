using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class SisterOfSlaughterTowModel : TowModel
{
    private static int pointsCost = 17;

    public SisterOfSlaughterTowModel(TowObject owner) : this(owner, m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 6, a: 2, ld: 9)
    {
        SetCommandGroup(new SisterOfSlaughterChampionTowModel(this), 7, 7, 7, 50, "Hag");

    }

    protected SisterOfSlaughterTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, DarkElvesTowModelType.SistersOfSlaughter, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {
        // special rules
        AssignSpecialRule(new DanceOfDeath());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new Impetuous());
        AssignSpecialRule(new Loner());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new OpenOrder());

        // weapons
        AssignDefault(new LashAndBucklerTowWeapon(this));
    }
}

public class SisterOfSlaughterChampionTowModel : SisterOfSlaughterTowModel
{
    public SisterOfSlaughterChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 6, a: 3, ld: 9)
    {
        
    }
}
