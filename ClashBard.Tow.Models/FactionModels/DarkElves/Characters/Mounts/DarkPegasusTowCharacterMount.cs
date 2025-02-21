using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;

public class DarkPegasusTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 35;
    private static DarkElvesTowModelMountType modelType = DarkElvesTowModelMountType.DarkPegasus;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.MonstrousCavalry;
    private const int baseSizeWidth = 40;
    private const int baseSizeLength = 60;
    private static int? armourValue = null;

    public DarkPegasusTowCharacterMount(TowObject owner) : this(owner, m: 8, ws: 3, bs: null, s: 4, t: null, toughnessAdded: null, w: null, woundsAdded: 1, i: 4, a: 3, ld: null)
    {
        // special rules
        AssignSpecialRule(new ArmourBane1("(Dark Pegasus only)"));
        AssignSpecialRule(new CounterCharge());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new Fly10());
        AssignSpecialRule(new Swiftstride());
    }

    protected DarkPegasusTowCharacterMount(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int i, int a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
    }
}
