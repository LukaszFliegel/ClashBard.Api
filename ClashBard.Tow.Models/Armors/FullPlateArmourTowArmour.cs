using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class FullPlateArmourTowArmour : TowArmour
{
    public FullPlateArmourTowArmour(TowObject owner) : base(owner, TowArmourType.FullPlateArmour, 4, 4)
    {
        
    }
}
