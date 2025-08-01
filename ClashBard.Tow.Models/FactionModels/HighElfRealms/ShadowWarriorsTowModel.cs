using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class ShadowWarriorsTowModel : TowModel
{
    private static int pointsCost = 14;

    public ShadowWarriorsTowModel(TowObject owner) : this(owner, m: 5, ws: 5, bs: 5, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
        SetCommandGroup(new ShadowWarriorsChampionTowModel(this), 5, 5, 5, 50, "Shadow-walker");
    }

    protected ShadowWarriorsTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.ShadowWarriors, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new HatredDarkElves());
        AssignSpecialRule(new Scouts());
        AssignSpecialRule(new Skirmishers());
        AssignSpecialRule(new ForestStrider());

        // weapons        
        AvailableWeapons.Add((TowWeaponType.Longbow, 0)); // Default weapon

        // armours
        AssignDefault(new LightArmourTowArmour(this));
    }
}

public class ShadowWarriorsChampionTowModel : ShadowWarriorsTowModel
{
    public ShadowWarriorsChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 5, s: 3, t: 3, w: 1, i: 5, a: 2, ld: 8)
    {
        
    }
}
