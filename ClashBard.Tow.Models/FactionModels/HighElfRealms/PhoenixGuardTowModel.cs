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
        SetCommandGroup(new PhoenixGuardChampionTowModel(this), 5, 5, 5, 50, "Keeper of the Flame");
    }

    protected PhoenixGuardTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, HighElvesTowModelType.PhoenixGuard, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new HighElvesTowFaction(), 25, 25, minUnitSize: 10)
    {                
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new ImmuneToPsychology());
        AssignSpecialRule(new WardSave4Plus());

        // weapons        
        // Phoenix Guard carry halberds (will use weapon type assignment instead of instantiating)
        AvailableWeapons.Add((TowWeaponType.Halberd, 0)); // They come with halberds by default

        // armours
        AssignDefault(new HeavyArmourTowArmour(this));
    }
}

public class PhoenixGuardChampionTowModel : PhoenixGuardTowModel
{
    public PhoenixGuardChampionTowModel(TowObject owner)
        : base(owner, m: 5, ws: 5, bs: 4, s: 3, t: 3, w: 1, i: 5, a: 2, ld: 9)
    {
        
    }
}
