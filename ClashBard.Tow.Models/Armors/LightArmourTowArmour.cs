using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class LightArmourTowArmour : TowArmour
{
    public LightArmourTowArmour(TowObject owner) : base(owner, TowArmourType.LightArmour, 6, 6)
    {
        
    }
}
