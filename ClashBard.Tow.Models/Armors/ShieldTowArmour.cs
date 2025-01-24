using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class ShieldTowArmour : TowArmour
{
    public ShieldTowArmour(TowObject owner) : base(owner, TowArmourType.Shield, 
        meleeSaveImprovement: 1,
        rangedSaveImprovement: 1)
    {
        
    }
}
