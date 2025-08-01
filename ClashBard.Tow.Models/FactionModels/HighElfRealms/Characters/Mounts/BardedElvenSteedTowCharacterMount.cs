using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters.Mounts;

public class BardedElvenSteedTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 18;
    private static HighElvesTowModelMountType modelType = HighElvesTowModelMountType.BardedElvenSteed;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.HeavyCavalry;
    private const int baseSizeWidth = 25;
    private const int baseSizeLength = 50;
    private static int? armourValue = 2; // Barding provides armor

    public BardedElvenSteedTowCharacterMount(TowObject owner) : this(owner, m: 9, ws: 3, bs: null, s: 3, t: 3, toughnessAdded: null, w: 1, woundsAdded: null, i: 4, a: 1, ld: 5)
    {
    }

    protected BardedElvenSteedTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
        // Special rules
        AssignSpecialRule(new ElvenReflexes());
    }
}
