using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ColdOneChariotsTowModel : TowModel
{
    private static int pointsCost = 125;

    public ColdOneChariotsTowModel(TowObject owner) : this(owner, m: null, ws: null, bs: null, s: 5, t: 5, w: 4, i: null, a: null, ld: null)
    {
        
    }

    protected ColdOneChariotsTowModel(TowObject owner, int? m, int? ws, int? bs, int s, int t, int w, int? i, int? a, int? ld) 
        : base(owner, DarkElfTowModelType.ColdOneChariots, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyCavalry, new DarkElvesTowFaction(), 50, 100, 1, 1, 4)
    {
        Crew.Add(new ColdOneTowModelAdditional(this));
        Crew.Add(new ColdOneTowModelAdditional(this));

        Crew.Add(new KnightCharioteerTowModelAdditional(this));
        Crew.Add(new KnightCharioteerTowModelAdditional(this));

        //SpecialRules.Add(new ArmourBane1()); // cold one only
        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new Fear());
        SpecialRules.Add(new FirstCharge());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new ImpactHitsD6Plus1());
        SpecialRules.Add(new Stupidity());
    }
}
