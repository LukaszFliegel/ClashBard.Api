using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class ChayalTowWeapon : TowWeapon
{
    public ChayalTowWeapon(TowObject owner) 
        : base(owner, TowWeaponType.Chayal, 0, TowWeaponStrength.Splus2, -3)
    {
        // Special rules: Killing Blow, Requires Two Hands
        // The wielder of Chayal may re-roll any rolls To Hit of a natural 1 made during the Combat phase
    }
}
