using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.Models.Weapons.FactionWeapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class MerwymTowModel : TowModel
{
    private static int pointsCost = 225;

    public MerwymTowModel(TowObject owner)
        : base(owner, HighElvesTowModelType.Merwyrm, m: 6, ws: 6, bs: 0, s: 6, t: 6, w: 6, i: 3, a: 4, ld: 8, pointCost: pointsCost, TowModelTroopType.Behemoth, new HighElvesTowFaction(), 60, 100, minUnitSize: 1, maxUnitSize: 1)
    {
        // special rules
        AssignSpecialRule(new AbyssalCloak());
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new EnfeeblingCold());
        AssignSpecialRule(new ImpactHitsD3());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new StompAttacksD3Plus1());
        AssignSpecialRule(new Terror());

        // weapons
        Assign(new LashingTalonsTowWeapon(this));
        Assign(new SerpentineTailTowWeapon(this));
        Assign(new BrinyBreathTowWeapon(this));

        // armour - Iridescent scales (Heavy armour)
        AssignDefault(new HeavyArmourTowArmour(this));
    }
}
