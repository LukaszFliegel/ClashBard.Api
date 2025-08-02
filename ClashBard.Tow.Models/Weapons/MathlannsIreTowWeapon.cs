using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class MathlannsIreTowWeapon : TowWeapon
{
    public MathlannsIreTowWeapon(TowObject owner) 
        : base(owner, TowWeaponType.MathlannsIre, 0, TowWeaponStrength.Splus1, -2)
    {
        // Special rule: During the Combat phase, enemy models must re-roll a single successful roll To Hit made against the wielder
        // Armour Bane (1), Magical Attacks
    }
}
