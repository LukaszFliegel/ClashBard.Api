using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters.Mounts;

public class StarDragonTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 350;
    private static HighElvesTowModelMountType modelType = HighElvesTowModelMountType.StarDragon;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.Behemoth;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int armourValue = 3;

    public StarDragonTowCharacterMount(TowObject owner) : this(owner, m: 6, ws: 7, bs: null, s: 7, t: 7, toughnessAdded: null, w: 6, woundsAdded: null, i: 3, a: 5, ld: 9)
    {
    }

    protected StarDragonTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
        // Special rules
        AssignSpecialRule(new Fly9());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new Terror());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MagicResistance2());

        // Dragon breath weapon (would need to implement breath weapon rules)
        // AssignSpecialRule(new BreathWeapon());
    }
}
