using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class KnightCharioteerTowModelAdditional : TowModelAdditional
{
    public KnightCharioteerTowModelAdditional(TowObject owner) : this(owner, m: null, ws: 5, bs: 4, s: 4, t: null, w: null, i: 5, a: 1, ld: 9)
    {
        Assign(new CavalrySpearTowWeapon(this));
        Assign(new RepeaterCrossbowTowWeapon(this));

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new Fear());
        SpecialRules.Add(new FirstCharge());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new ImpactHitsD6Plus1());
        SpecialRules.Add(new Stupidity());
    }

    protected KnightCharioteerTowModelAdditional(TowObject owner, int? m, int ws, int bs, int s, int? t, int? w, int i, int a, int ld)
        : base(owner, DarkElfTowModelAdditionalType.KnightCharioteer, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

