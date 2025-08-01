using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters.Mounts;

public class GriffonTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 150;
    private static HighElvesTowModelMountType modelType = HighElvesTowModelMountType.Griffon;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.MonstrousCreature;
    private const int baseSizeWidth = 50;
    private const int baseSizeLength = 75;
    private const int armourValue = 5;

    public GriffonTowCharacterMount(TowObject owner) : this(owner, m: 6, ws: 5, bs: null, s: 5, t: 5, toughnessAdded: null, w: 4, woundsAdded: null, i: 5, a: 3, ld: 8)
    {
    }

    protected GriffonTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
        // Special rules
        AssignSpecialRule(new Fly9());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new Terror());
        AssignSpecialRule(new ValourOfAges());
    }
}
