using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class ChracianWoodsmenTowModel : TowModel
{
    private static int pointsCost = 12;

    public ChracianWoodsmenTowModel(TowObject owner) : this(owner, m: 5, ws: 4, bs: 4, s: 4, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new ChracianWoodsmenChampionTowModel(this), 7, 7, 7, 50, "Chracian Captain");
    }

    protected ChracianWoodsmenTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.ChracianWoodsmen, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // Special rules - as per official rules and JSON
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new MoveThroughCover());
        AssignSpecialRule(new Skirmishers());
        AssignSpecialRule(new ValourOfAges());

        // Default equipment - Hand weapons, Chracian great blades, Light armour
        // Hand weapon - inherited from TowModel base class
        AssignDefault(new ChracianGreatBladeTowWeapon(this)); // Default Chracian great blade
        AssignDefault(new LightArmourTowArmour(this)); // Default light armour

        // Equipment options (from JSON)
        // Warbows (+1 pt per model)
        AvailableWeapons.Add((TowWeaponType.Warbow, 1));

        // Armor options
        AvailableArmours.Add((TowArmourType.HeavyArmour, 1));

        // Special rule options (mutually exclusive deployment options)
        // Vanguard (0 pts, default active in JSON)
        AssignSpecialRule(new Vanguard());
        
        // Alternative deployment options (exclusive):
        // Scouts (0 pts, 0-1 unit limit)
        AvailableSpecialRules.Add((TowSpecialRuleType.Scouts, 0));
        
        // Ambushers (+1 pt per model, 0-1 unit limit)
        AvailableSpecialRules.Add((TowSpecialRuleType.Ambushers, 1));
        
        // Lion Cloak (+1 pt per model)
        AvailableSpecialRules.Add((TowSpecialRuleType.LionCloak, 1));
    }
}

public class ChracianWoodsmenChampionTowModel : ChracianWoodsmenTowModel
{
    public ChracianWoodsmenChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 4, bs: 4, s: 4, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
