using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class HeavyArmourTowArmour : TowArmour
{
    public HeavyArmourTowArmour(TowObject owner) : base(owner, TowArmourType.HeavyArmour, 5, 5)
    {
        
    }
}
