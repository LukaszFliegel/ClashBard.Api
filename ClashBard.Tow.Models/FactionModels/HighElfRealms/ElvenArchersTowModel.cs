using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class ElvenArchersTowModel : TowModel
{
    private static int pointsCost = 10;

    public ElvenArchersTowModel(TowObject owner) : this(owner, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new ElvenArchersChampionTowModel(this), 5, 5, 5, 25, "Sentinel");
    }

    protected ElvenArchersTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.Archers, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // Special rules - as per official rules and JSON
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new Detachment());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());

        // Default equipment - Hand weapons, Longbows (both active per JSON)
        // Hand weapon - inherited from TowModel base class
        AssignDefault(new LongbowTowWeapon(this));

        // Equipment options (from JSON)
        // Light armour (+1 pt per model)
        AvailableArmours.Add((TowArmourType.LightArmour, 1));

        // Special rule options
        // Veteran (+1 pt per model)
        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));

        // Special options for Chracian Warhost composition (from JSON)
        // Move Through Cover (+1 pt per model, 0-1 unit per 1000 points)
        AvailableSpecialRules.Add((TowSpecialRuleType.MoveThroughCover, 1));

        // Lion Cloak (+10 pts for Chracian Warhost)
        AvailableSpecialRules.Add((TowSpecialRuleType.LionCloak, 10));
    }
}

public class ElvenArchersChampionTowModel : ElvenArchersTowModel
{
    public ElvenArchersChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 4, bs: 5, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8) // Note: BS5 for Sentinel champion
    {
        
    }
}
