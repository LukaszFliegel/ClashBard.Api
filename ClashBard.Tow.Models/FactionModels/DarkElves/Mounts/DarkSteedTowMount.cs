using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DarkSteedTowMount : TowModelMount
{
    private static int pointsCost = 14;

    public DarkSteedTowMount() : this(m: 9, ws: 3, bs: null, s: 3, t: null, toughnessAdded: null, w: null, woundsAdded: null, i: 4, a: 1, ld: null)
    {
        SpecialRules.Add(new FastCavalry());
        SpecialRules.Add(new Swiftstride());        
    }

    protected DarkSteedTowMount(int? m, int ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int i, int a, int? ld) 
        : base(TowModelMountType.DarkSteed, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightCavalry, new DarkElvesTowFaction(), 30, 60)
    {
    }
}
