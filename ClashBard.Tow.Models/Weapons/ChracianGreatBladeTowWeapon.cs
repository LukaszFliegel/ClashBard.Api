using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class ChracianGreatBladeTowWeapon : TowWeapon
{
    public ChracianGreatBladeTowWeapon(TowObject owner) 
        : base(owner, TowWeaponType.ChracianGreatBlade, 0, TowWeaponStrength.Splus2, -3)
    {
        // Special rules: Requires Two Hands, Strike Last
        // Traditional woodsman's axe of the White Lions of Chrace
    }
}
