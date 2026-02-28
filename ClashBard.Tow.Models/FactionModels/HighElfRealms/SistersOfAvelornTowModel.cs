using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class SistersOfAvelornTowModel : TowModel
{
    private static int pointsCost = 15;

    public SistersOfAvelornTowModel(TowObject owner) : this(owner, m: 5, ws: 5, bs: 5, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
        SetCommandGroup(new SistersOfAvelornHighSisterTowModel(this), 7, null, null, championName: "High Sister", championMagicItemsUpToPoints: 50);
    }

    protected SistersOfAvelornTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.SistersOfAvelorn, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {
        // special rules
        AssignSpecialRule(new ArrowsOfIsha());
        AssignSpecialRule(new Evasive());
        AssignSpecialRule(new IgnoresCover());
        AssignSpecialRule(new ImmuneToPsychology());
        AssignSpecialRule(new IthilmarArmour());
        AssignSpecialRule(new IthilmarWeapons());
        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new Skirmishers());
        AssignSpecialRule(new StrikeFirst());

        // weapons - Hand weapons (base) + Bows of Avelorn (default)
        AssignDefault(new BowOfAvelornTowWeapon(this));

        // armours - Light armour (default)
        AssignDefault(new LightArmourTowArmour(this));

        // optional upgrades (per-model)
        AvailableSpecialRules.Add((TowSpecialRuleType.Stubborn, 1));
        AvailableSpecialRules.Add((TowSpecialRuleType.Ambushers, 1));
    }
}

public class SistersOfAvelornHighSisterTowModel : SistersOfAvelornTowModel
{
    public SistersOfAvelornHighSisterTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 6, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
    }
}
