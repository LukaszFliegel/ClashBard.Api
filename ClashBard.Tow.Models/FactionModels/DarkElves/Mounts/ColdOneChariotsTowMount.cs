using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ColdOneChariotsTowMount : TowModelMount
{
    private static int pointsCost = 125;

    public ColdOneChariotsTowMount(TowObject owner) : this(owner, m: null, ws: null, bs: null, s: 5, t: 5, toughnessAdded: null, w: 4, woundsAdded: null, i: null, a: null, ld: null)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new ImpactHitsD6Plus1());
        AssignSpecialRule(new Stupidity());

        // crew
        Crew.Add(new ColdOneTowModelAdditional(this));
        Crew.Add(new ColdOneTowModelAdditional(this));

        Crew.Add(new KnightCharioteerTowModelAdditional(this));
        Crew.Add(new KnightCharioteerTowModelAdditional(this));
    }

    protected ColdOneChariotsTowMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld) 
        : base(owner, TowModelMountType.ColdOneChariot, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyCavalry, new DarkElvesTowFaction(), 50, 100, 1, 1, 4)
    {
    }
}
