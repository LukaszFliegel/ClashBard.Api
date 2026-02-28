using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.MagicWeapons;

/// <summary>
/// Finely fashioned from blackest steel, Lifetaker fires bolts dipped in the venom of a Black Dragon.
/// 24", S3, AP-1. Armour Bane (1), Magical Attacks, Multiple Shots (D3+1), Poisoned Attacks.
/// 35 points.
/// </summary>
public class LifetakerTowMagicWeapon : TowMagicWeapon
{
    private const int points = 35;

    public LifetakerTowMagicWeapon(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.Lifetaker, points, 24, TowWeaponStrength.Three, 1)
    {
        AssignSpecialRule(new ArmourBane1());
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new MultipleShotsD3Plus1());
        AssignSpecialRule(new PoisonedAttacks());
    }
}
