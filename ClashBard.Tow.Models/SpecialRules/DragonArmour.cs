using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class DragonArmour : TowSpecialRule
{
    private static string ShortDescription = "Dragon Armour";
    private static string LongDescription = "A model with this special rule has the natural armored scales of a dragon, providing enhanced protection equivalent to full plate armour while maintaining the creature's mobility and agility.";

    public DragonArmour()
        : base(TowSpecialRuleType.DragonArmour,
              ShortDescription,
              LongDescription)
    {
    }
}
