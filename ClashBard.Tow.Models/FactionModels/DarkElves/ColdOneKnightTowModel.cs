using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ColdOneKnightTowModel : TowModel
{
    private static int pointsCost = 31;

    public ColdOneKnightTowModel() : this(m: null, ws: 5, bs: 4, s: 4, t: 4, w: 1, i: 5, a: 1, ld: 9)
    {
        SetCommandGroup(new ColdOneKnightChampionTowModel(), 7, 7, 7, 50, "Dread Knight", 50);
    }

    protected ColdOneKnightTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.ColdOneKnights, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyCavalry, new DarkElvesTowFaction(), 30, 60, minUnitSize: 5)
    {
        Armours.Add(new HeavyArmourTowArmour());
        Armours.Add(new ShieldTowArmour());

        AvailableArmours.Add((TowArmourType.FullPlateArmour, 4));

        Weapons.Add(new LanceTowWeapon());

        SpecialRules.Add(new ArmouredHide1());
        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new Fear());
        SpecialRules.Add(new FirstCharge());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new Stupidity());
        SpecialRules.Add(new Swiftstride());

        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));

        Mount = new ColdOneTowMount();
    }
}

public class ColdOneKnightChampionTowModel : ColdOneKnightTowModel
{
    public ColdOneKnightChampionTowModel()
        : base(m: null, ws: 5, bs: 4, s: 4, t: 4, w: 1, i: 5, a: 2, ld: 9)
    {
        
    }
}
