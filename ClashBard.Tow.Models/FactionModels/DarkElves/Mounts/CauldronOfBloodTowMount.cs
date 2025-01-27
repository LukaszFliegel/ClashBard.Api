using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class CauldronOfBloodTowMount : TowModelMount
{
    private static int pointsCost = 150;

    public CauldronOfBloodTowMount(TowObject owner) : this(owner, m: 2, ws: null, bs: null, s: 5, t: 5, toughnessAdded: null, w: 5, woundsAdded: null, i: null, a: null, ld: null)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new DraggedAlong());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Frenzy());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new ImpactHitsD6Plus1());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new MagicResistance1());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new PoisonedAttacks());
        AssignSpecialRule(new Terror());
        AssignSpecialRule(new BlessingsOfKhaine());

        // crew
        Crew.Add(new WitchElfCrewTowModelAdditional(this));
        Crew.Add(new WitchElfCrewTowModelAdditional(this));
    }

    protected CauldronOfBloodTowMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld) 
        : base(owner, TowModelMountType.CauldronOfBlood, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyChariot, new DarkElvesTowFaction(), 60, 100, 1, 1, 4)
    {
    }
}
