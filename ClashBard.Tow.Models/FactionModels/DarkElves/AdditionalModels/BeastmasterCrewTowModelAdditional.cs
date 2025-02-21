using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class BeastmasterCrewTowModelAdditional : TowModelAdditional
{
    public BeastmasterCrewTowModelAdditional(TowObject owner) : this(owner, m: null, ws: 4, bs: 4, s: 3, t: null, w: null, i: 4, a: 1, ld: 8)
    {
        Assign(new CavalrySpearTowWeapon(this));
        Assign(new RepeaterCrossbowTowWeapon(this));
        
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new HatredHighElves());
    }

    protected BeastmasterCrewTowModelAdditional(TowObject owner, int? m, int ws, int bs, int s, int? t, int? w, int i, int a, int ld)
        : base(owner, DarkElvesTowModelAdditionalType.BeastmasterHandlers, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

