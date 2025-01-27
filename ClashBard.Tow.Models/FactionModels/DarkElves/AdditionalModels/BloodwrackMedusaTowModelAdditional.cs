using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class BloodwrackMedusaTowModelAdditional : TowModelAdditional
{
    public BloodwrackMedusaTowModelAdditional(TowObject owner) : this(owner, m: null, ws: 5, bs: 5, s: 4, t: null, w: null, i: 5, a: 3, ld: null)
    {
        Assign(new CavalrySpearTowWeapon(this));
        Assign(new PetrifyingGazeTowWeapon(this));

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
    }

    protected BloodwrackMedusaTowModelAdditional(TowObject owner, int? m, int ws, int bs, int s, int? t, int? w, int i, int a, int? ld)
        : base(owner, DarkElfTowModelAdditionalType.BloodwrackMedusa, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

