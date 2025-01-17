using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.Net.Http.Headers;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ColdOneChariotsTowMount : TowModelMount
{
    private static int pointsCost = 125;

    public ColdOneChariotsTowMount() : this(m: null, ws: null, bs: null, s: 5, t: 5, toughnessAdded: null, w: 4, woundsAdded: null, i: null, a: null, ld: null)
    {
        Crew.Add(new ColdOneTowModelAdditional());
        Crew.Add(new ColdOneTowModelAdditional());

        Crew.Add(new KnightCharioteerTowModelAdditional());
        Crew.Add(new KnightCharioteerTowModelAdditional());

        //SpecialRules.Add(new ArmourBane1()); // cold one only
        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new Fear());
        SpecialRules.Add(new FirstCharge());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new ImpactHitsD6Plus1());
        SpecialRules.Add(new Stupidity());
    }

    protected ColdOneChariotsTowMount(int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld) 
        : base(TowModelMountType.ColdOneChariot, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyCavalry, new DarkElvesTowFaction(), 50, 100, 1, 1, 4)
    {
    }
}
