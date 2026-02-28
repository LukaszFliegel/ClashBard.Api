using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class SwordMastersOfHoethTowModel : TowModel
{
    private static int pointsCost = 14;

    public SwordMastersOfHoethTowModel(TowObject owner) : this(owner, m: 5, ws: 6, bs: 4, s: 3, t: 3, w: 1, i: 6, a: 1, ld: 8)
    {
        SetCommandGroup(new SwordMastersOfHoethChampionTowModel(this), 5, 5, 5, 50, "Bladelord");
    }

    protected SwordMastersOfHoethTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.SwordMastersOfHoeth, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // special rules per JSON
        AssignSpecialRule(new CleavingBlow());
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new DeflectShots());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new IthilmarArmour());
        AssignSpecialRule(new MagicResistance1());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new WarriorsOfTheWhiteTower());

        // options
        AvailableSpecialRules.Add((TowSpecialRuleType.Drilled, 1));

        // weapons - Swords of Hoeth (magical great swords, default equipment)
        AssignDefault(new SwordsOfHoethTowWeapon(this));

        // armours - Heavy armour (default active equipment per JSON)
        AssignDefault(new HeavyArmourTowArmour(this));
    }
}

public class SwordMastersOfHoethChampionTowModel : SwordMastersOfHoethTowModel
{
    public SwordMastersOfHoethChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 6, bs: 4, s: 3, t: 3, w: 1, i: 6, a: 2, ld: 8)
    {
        
    }
}
