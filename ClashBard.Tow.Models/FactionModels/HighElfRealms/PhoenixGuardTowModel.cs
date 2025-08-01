using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class PhoenixGuardTowModel : TowModel
{
    private static int pointsCost = 16;

    public PhoenixGuardTowModel(TowObject owner) : this(owner, m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 9)
    {
        SetCommandGroup(new PhoenixGuardChampionTowModel(this), 7, 7, 7, 25, "Keeper of the Flame");
    }

    protected PhoenixGuardTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.PhoenixGuard, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 5)
    {                
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new Veteran());
        // TODO: Missing special rules: BlessingsOfAsuryan, WitnessToDestiny

        // weapons        
        // Phoenix Guard carry ceremonial halberds (will use weapon type assignment instead of instantiating)
        AvailableWeapons.Add((TowWeaponType.Halberd, 0)); // They come with halberds by default

        // armours
        AssignDefault(new FullPlateArmourTowArmour(this));
        
        // options
        AvailableSpecialRules.Add((TowSpecialRuleType.Drilled, 1));
    }
}

public class PhoenixGuardChampionTowModel : PhoenixGuardTowModel
{
    public PhoenixGuardChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 5, a: 2, ld: 9)
    {
        
    }
}
