using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DarkSteedTowModelAdditional : TowModelAdditional
{
    public DarkSteedTowModelAdditional(TowObject owner) : this(owner, m: 9, ws: 3, bs: null, s: 3, t: null, w: null, i: 4, a: 1, ld: null)
    {
        AssignSpecialRule(new Swiftstride());
    }

    protected DarkSteedTowModelAdditional(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int? ld)
        : base(owner, DarkElvesTowModelAdditionalType.DarkSteed, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

