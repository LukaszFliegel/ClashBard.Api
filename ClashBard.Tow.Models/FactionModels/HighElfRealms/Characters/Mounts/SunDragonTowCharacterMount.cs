using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters.Mounts;

public class SunDragonTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 280;
    private static HighElvesTowModelMountType modelType = HighElvesTowModelMountType.SunDragon;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.Behemoth;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int armourValue = 4;

    public SunDragonTowCharacterMount(TowObject owner) : this(owner, m: 6, ws: 6, bs: null, s: 6, t: 6, toughnessAdded: null, w: 5, woundsAdded: null, i: 3, a: 4, ld: 8)
    {
    }

    protected SunDragonTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
        // Special rules
        AssignSpecialRule(new Fly9());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new Terror());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MagicResistance1());

        // Dragon breath weapon (would need to implement breath weapon rules)
        // AssignSpecialRule(new BreathWeapon());
    }
}
