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
    }

    protected BloodwrackMedusaTowModelAdditional(TowObject owner, int? m, int ws, int bs, int s, int? t, int? w, int i, int a, int? ld)
        : base(owner, DarkElfTowModelAdditionalType.BloodwrackMedusa, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

