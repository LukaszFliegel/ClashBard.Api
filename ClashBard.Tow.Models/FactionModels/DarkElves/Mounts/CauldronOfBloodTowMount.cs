using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class CauldronOfBloodTowMount : TowModelMount
{
    private static int pointsCost = 150;

    public CauldronOfBloodTowMount() : this(m: 2, ws: null, bs: null, s: 5, t: 5, toughnessAdded: null, w: 5, woundsAdded: null, i: null, a: null, ld: null)
    {        
        Crew.Add(new WitchElfCrewTowModelAdditional());
        Crew.Add(new WitchElfCrewTowModelAdditional());

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new DraggedAlong());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new Frenzy());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new ImpactHitsD6Plus1());
        SpecialRules.Add(new LargeTarget());
        SpecialRules.Add(new MagicResistance1());
        SpecialRules.Add(new Murderous());
        SpecialRules.Add(new PoisonedAttacks());
        SpecialRules.Add(new Terror());
        SpecialRules.Add(new BlessingsOfKhaine());        
    }

    protected CauldronOfBloodTowMount(int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld) 
        : base(TowModelMountType.CauldronOfBlood, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyChariot, new DarkElvesTowFaction(), 60, 100, 1, 1, 4)
    {
    }
}
