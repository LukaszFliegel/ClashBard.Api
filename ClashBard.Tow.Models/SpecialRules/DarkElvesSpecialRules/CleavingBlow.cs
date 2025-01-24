using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class CleavingBlow : TowSpecialRule
{
    private static string ShortDescription = "No armor save when 6 on wound";
    private static string LongDescription = "If a model with this special rule rolls a natural 6 when making a roll To Wound for an attack made in combat, it has struck a ‘Cleaving Blow’. Enemy models whose troop type is ‘regular infantry’, ‘heavy infantry’, ‘light cavalry’, ‘heavy cavalry’ or ‘war beasts’ are not permitted an armour or Regeneration save against a Cleaving Blow (Ward saves can be attempted as normal). Note that if an attack wounds automatically, this special rule cannot be used.";

    public CleavingBlow()
        : base(TowSpecialRuleType.CleavingBlow,
            ShortDescription,
            LongDescription)
    {

    }
}
