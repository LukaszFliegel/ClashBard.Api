using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters.Mounts;

public class MoonDragonTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 240;
    private static HighElvesTowModelMountType modelType = HighElvesTowModelMountType.MoonDragon;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.Behemoth;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int armourValue = 5;

    public MoonDragonTowCharacterMount(TowObject owner) : this(owner, m: 6, ws: 5, bs: null, s: 5, t: 5, toughnessAdded: null, w: 4, woundsAdded: null, i: 3, a: 3, ld: 8)
    {
    }

    protected MoonDragonTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
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
