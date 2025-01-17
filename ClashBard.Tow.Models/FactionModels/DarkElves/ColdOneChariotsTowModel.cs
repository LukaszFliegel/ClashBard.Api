using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ColdOneChariotsTowModel : TowModel
{
    private static int pointsCost = 125;

    public ColdOneChariotsTowModel() : this(m: null, ws: null, bs: null, s: 5, t: 5, w: 4, i: null, a: null, ld: null)
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

    protected ColdOneChariotsTowModel(int? m, int? ws, int? bs, int s, int t, int w, int? i, int? a, int? ld) 
        : base(DarkElfTowModelType.ColdOneChariots, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyCavalry, new DarkElvesTowFaction(), 50, 100, 1, 1, 4)
    {
    }
}
