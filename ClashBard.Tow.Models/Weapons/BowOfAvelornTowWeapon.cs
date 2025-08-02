using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class BowOfAvelornTowWeapon : TowWeapon
{
    public BowOfAvelornTowWeapon(TowObject owner) 
        : base(owner, TowWeaponType.BowOfAvelorn, 24, TowWeaponStrength.Four, 0)
    {
    }
}
