using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ScourgerunnerChariotTowMount : TowModelMount
{
    private static int pointsCost = 85;

    public ScourgerunnerChariotTowMount(TowObject owner) : this(owner, m: null, ws: null, bs: 4, s: 4, t: 4, toughnessAdded: null, w: 4, woundsAdded: 4, i: null, a: null, ld: 4)
    {
        Crew.Add(new DarkSteedTowModelAdditional(this));
        Crew.Add(new DarkSteedTowModelAdditional(this));

        Crew.Add(new BeastmasterCrewTowModelAdditional(this));
        Crew.Add(new BeastmasterCrewTowModelAdditional(this));

        Assign(new RavagerHarpoonTowWeapon(this));

        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new ImpactHitsD6());        
        AssignSpecialRule(new SeaDragonCloak());
        AssignSpecialRule(new Swiftstride());
    }

    protected ScourgerunnerChariotTowMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld) 
        : base(owner, TowModelMountType.ScourgerunnerChariot, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightChariot, new DarkElvesTowFaction(), 50, 100, 1, 3, 5)
    {
    }
}
