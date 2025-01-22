using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class SeaDragonCloakTowArmour : TowArmour
{
    public SeaDragonCloakTowArmour() : base(TowArmourType.SeaDragonCloak, 
        rangedSaveImprovement: 1,
        asteriskOnSave: true)
    {
        SpecialRules.Add(new SeaDragonCloakTowArmourRules());
    }
}

public class SeaDragonCloakTowArmourRules : TowSpecialRule
{
    private static new string ShortDescription = "+1 save against non-magical";
    private static new string LongDescription = "A model with this special rule improves its armour value by 1 (to a maximum of 2+) against non-magical shooting attacks.";

    public SeaDragonCloakTowArmourRules()
        : base(TowSpecialRuleType.SeaDragonCloakTowArmourRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}