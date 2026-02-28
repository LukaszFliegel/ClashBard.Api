using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class ShadowWarriorsTowModel : TowModel
{
    private static int pointsCost = 14;

    public ShadowWarriorsTowModel(TowObject owner) : this(owner, m: 5, ws: 5, bs: 5, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
        SetCommandGroup(new ShadowWarriorsChampionTowModel(this), 6, 5, 5, 25, "Shadow-walker");
    }

    protected ShadowWarriorsTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.ShadowWarriors, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Evasive());
        AssignSpecialRule(new FireAndFlee());
        AssignSpecialRule(new IthilmarWeapons());
        AssignSpecialRule(new MoveThroughCover());
        AssignSpecialRule(new Scouts());
        AssignSpecialRule(new Skirmishers());
        AssignSpecialRule(new Veteran());
        AssignSpecialRule(new WarriorsOfNagarythe());

        // weapons - longbow is default equipment        
        AssignDefault(new LongbowTowWeapon(this));

        // armours
        AssignDefault(new LightArmourTowArmour(this));
        
        // optional upgrades (0-1 unit each)
        AvailableSpecialRules.Add((TowSpecialRuleType.Ambushers, 1)); // +1 pt per model, 0-1 unit
        AvailableSpecialRules.Add((TowSpecialRuleType.ChariotRunners, 1)); // +1 pt per model, 0-1 unit  
        AvailableSpecialRules.Add((TowSpecialRuleType.FeignedFlight, 1)); // +1 pt per model, 0-1 unit
    }
}

public class ShadowWarriorsChampionTowModel : ShadowWarriorsTowModel
{
    public ShadowWarriorsChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 6, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
        
    }
}
