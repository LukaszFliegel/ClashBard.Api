using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class VenomousTailTowWeapon : TowWeapon
{
    public VenomousTailTowWeapon() : base(TowTypes.TowWeaponType.VenomousTail, 0, TowWeaponStrength.S, 0)
    {
        SpecialRules.Add(new PoisonedAttacks());
        SpecialRules.Add(new StrikeFirst());
        SpecialRules.Add(new VenomousTailNotes());
    }
}
