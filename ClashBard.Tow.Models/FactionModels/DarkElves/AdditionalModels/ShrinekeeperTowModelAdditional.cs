using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ShrinekeeperTowModelAdditional : TowModelAdditional
{
    public ShrinekeeperTowModelAdditional() : this(m: null, ws: 4, bs: 4, s: 3, t: null, w: null, i: 5, a: 1, ld: 8)
    {
        Weapons.Add(new CavalrySpearTowWeapon());

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

    protected ShrinekeeperTowModelAdditional(int? m, int ws, int bs, int s, int? t, int? w, int i, int a, int ld)
        : base(DarkElfTowModelAdditionalType.WitchElfCrew, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

