using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class SwordMastersOfHoethTowModel : TowModel
{
    private static int pointsCost = 16;

    public SwordMastersOfHoethTowModel(TowObject owner) : this(owner, m: 5, ws: 6, bs: 4, s: 3, t: 3, w: 1, i: 6, a: 1, ld: 8)
    {
        SetCommandGroup(new SwordMastersOfHoethChampionTowModel(this), 5, 5, 5, 50, "Bladelord");
    }

    protected SwordMastersOfHoethTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.SwordMastersOfHoeth, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 10)
    {                
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new AlwaysStrikesFirst());

        // weapons - Sword Masters carry great weapons (greatswords)       
        AvailableWeapons.Add((TowWeaponType.GreatWeapon, 0)); 

        // armours - No armor, they rely on skill
        // No default armor assigned
    }
}

public class SwordMastersOfHoethChampionTowModel : SwordMastersOfHoethTowModel
{
    public SwordMastersOfHoethChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 6, bs: 4, s: 3, t: 3, w: 1, i: 6, a: 2, ld: 8)
    {
        
    }
}
