using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Mounts;

public class ElvenSteedTowMount : TowModelMount
{
    private static int pointsCost = 12;
    private static HighElvesTowModelMountType modelType = HighElvesTowModelMountType.ElvenSteed;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.LightCavalry;
    private const int baseSizeWidth = 30;
    private const int baseSizeLength = 60;

    public ElvenSteedTowMount(TowObject owner) : this(owner, m: 9, ws: 3, bs: null, s: 3, t: null, w: null, i: 4, a: 1, ld: null)
    {
        AssignSpecialRule(new FastCavalry());
        AssignSpecialRule(new Swiftstride());
    }

    protected ElvenSteedTowMount(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, troopType, faction, baseSizeWidth, baseSizeLength)
    {
    }
}
