using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class WitchElfTowModel : TowModel
{
    private static int pointsCost = 11;

    public WitchElfTowModel() : this(m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
        SetCommandGroup(new WitchElfChampionTowModel(), 7, 7, 7, 50, "Hag");

    }

    protected WitchElfTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.WitchElves, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {
        Weapons.Add(new AdditionalHandWeaponTowWeapon());

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new Frenzy());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new Horde());
        SpecialRules.Add(new Loner());
        SpecialRules.Add(new Murderous());
        SpecialRules.Add(new PoisonedAttacks());
    }
}

public class WitchElfChampionTowModel : WitchElfTowModel
{
    public WitchElfChampionTowModel()
        : base(m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 5, a: 2, ld: 8)
    {
        
    }
}
