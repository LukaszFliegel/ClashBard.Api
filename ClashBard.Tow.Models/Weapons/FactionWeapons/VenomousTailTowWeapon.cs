using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class VenomousTailTowWeapon : TowWeapon
{
    public VenomousTailTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.VenomousTail, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new PoisonedAttacks());
        AssignSpecialRule(new StrikeFirst());
        AssignSpecialRule(new VenomousTailNotes());
    }
}
