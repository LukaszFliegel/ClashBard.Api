using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Mounts;

public class BardedElvenSteedTowMount : TowModelMount
{
    private static int pointsCost = 18;
    private static HighElvesTowModelMountType modelType = HighElvesTowModelMountType.BardedElvenSteed;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.HeavyCavalry;
    private const int baseSizeWidth = 25;
    private const int baseSizeLength = 50;

    public BardedElvenSteedTowMount(TowObject owner) : this(owner, m: 8, ws: 3, bs: null, s: 3, t: null, w: null, i: 4, a: 1, ld: null)
    {
        // Barded elven steeds have armor protection but are slower
    }

    protected BardedElvenSteedTowMount(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, troopType, faction, baseSizeWidth, baseSizeLength)
    {
    }
}
