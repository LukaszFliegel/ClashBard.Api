using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ColdOneTowModelAdditional : TowModelAdditional
{
    public ColdOneTowModelAdditional() : this(m: 7, ws: 3, bs: null, s: 4, t: null, w: null, i: 2, a: 2, ld: null)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new ElvenReflexes()); // ?
        SpecialRules.Add(new Fear());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new Stupidity());
    }

    protected ColdOneTowModelAdditional(int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int? ld)
        : base(DarkElfTowModelAdditionalType.ColdOne, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

