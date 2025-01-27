using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ShrinekeeperTowModelAdditional : TowModelAdditional
{
    public ShrinekeeperTowModelAdditional(TowObject owner) : this(owner, m: null, ws: 4, bs: 4, s: 3, t: null, w: null, i: 5, a: 1, ld: 8)
    {
        Assign(new CavalrySpearTowWeapon(this));

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

    protected ShrinekeeperTowModelAdditional(TowObject owner, int? m, int ws, int bs, int s, int? t, int? w, int i, int a, int ld)
        : base(owner, DarkElfTowModelAdditionalType.WitchElfCrew, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

