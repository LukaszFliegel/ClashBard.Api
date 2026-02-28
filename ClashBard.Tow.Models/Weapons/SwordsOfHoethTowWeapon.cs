using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class SwordsOfHoethTowWeapon : TowWeapon
{
    public SwordsOfHoethTowWeapon(TowObject owner)
        : base(owner, TowWeaponType.SwordsOfHoeth, 0, TowWeaponStrength.Splus1, -2)
    {
        // Swords of Hoeth - magical great swords wielded by the Sword Masters of Hoeth
        // +1 Strength, -2 Armour Save modifier, requires two hands, grants Warriors of the White Tower
    }
}
