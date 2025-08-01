using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters.Mounts;

public class FlamesphyrePhoenixTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 200;
    private static HighElvesTowModelMountType modelType = HighElvesTowModelMountType.FlamesphyrePhoenix;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.MonstrousCreature;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int armourValue = 5;

    public FlamesphyrePhoenixTowCharacterMount(TowObject owner) : this(owner, m: 2, ws: 5, bs: null, s: 5, t: 5, toughnessAdded: null, w: 4, woundsAdded: null, i: 4, a: 2, ld: 8)
    {
    }

    protected FlamesphyrePhoenixTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
        // Special rules
        AssignSpecialRule(new Fly9());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new Terror());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new WardSave4Plus());
        // Phoenix specific abilities like phoenix reborn and wake of fire would need custom special rules
    }
}
