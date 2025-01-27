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

        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new ImpactHitsD6Plus1());
        AssignSpecialRule(new Stupidity());
    }

    protected KnightCharioteerTowModelAdditional(TowObject owner, int? m, int ws, int bs, int s, int? t, int? w, int i, int a, int ld)
        : base(owner, DarkElfTowModelAdditionalType.KnightCharioteer, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

