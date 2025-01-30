using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Mounts;

public class DarkSteedTowMount : TowModelMount
{
    private static int pointsCost = 14;
    private static DarkElfTowModelMountType modelType = DarkElfTowModelMountType.DarkSteed;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.LightCavalry;
    private const int baseSizeWidth = 30;
    private const int baseSizeLength = 60;

    public DarkSteedTowMount(TowObject owner) : this(owner, m: 9, ws: 3, bs: null, s: 3, t: null, w: null, i: 4, a: 1, ld: null)
    {
        // special rules
        AssignSpecialRule(new FastCavalry());
        AssignSpecialRule(new Swiftstride());
    }

    protected DarkSteedTowMount(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, troopType, faction, baseSizeWidth, baseSizeLength)
    {
    }
}
