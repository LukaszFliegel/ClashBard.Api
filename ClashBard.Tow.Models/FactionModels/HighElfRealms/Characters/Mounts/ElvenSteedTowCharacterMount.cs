using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters.Mounts;

public class ElvenSteedTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 12;
    private static HighElvesTowModelMountType modelType = HighElvesTowModelMountType.ElvenSteed;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.LightCavalry;
    private const int baseSizeWidth = 25;
    private const int baseSizeLength = 50;
    private static int? armourValue = null;

    public ElvenSteedTowCharacterMount(TowObject owner) : this(owner, m: 9, ws: 3, bs: null, s: 3, t: 3, toughnessAdded: null, w: 1, woundsAdded: null, i: 4, a: 1, ld: 5)
    {
    }

    protected ElvenSteedTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
        // Special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new FastCavalry());
        AssignSpecialRule(new Swiftstride());
    }
}
