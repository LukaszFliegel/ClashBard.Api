using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class BeastmasterCrewTowModelAdditional : TowModelAdditional
{
    public BeastmasterCrewTowModelAdditional() : this(m: null, ws: 4, bs: 4, s: 3, t: null, w: null, i: 4, a: 1, ld: 8)
    {
        Weapons.Add(new CavalrySpearTowWeapon());
        Weapons.Add(new RepeaterCrossbowTowWeapon());
        
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new HatredHighElves());
    }

    protected BeastmasterCrewTowModelAdditional(int? m, int ws, int bs, int s, int? t, int? w, int i, int a, int ld)
        : base(DarkElfTowModelAdditionalType.BeastmasterCrew, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

