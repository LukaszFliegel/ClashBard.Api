using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class KillingBlow : TowSpecialRule
{
    private static string ShortDescription = "The most skilled of warriors can slay their enemies with a single deadly blow.";
    private static string LongDescription = "If a model with this special rule rolls a natural 6 when making a roll To Wound for an attack made in combat, it has struck a 'Killing Blow'. Enemy models whose troop type is infantry or cavalry are not permitted an armour or Regeneration save against a Killing Blow (Ward saves can be attempted as normal). If an enemy model whose troop type is infantry or cavalry suffers an unsaved wound from a Killing Blow, it loses all of its remaining Wounds. Note that if an attack wounds automatically, this special rule cannot be used.";

    public KillingBlow()
        : base(TowSpecialRuleType.KillingBlow,
            ShortDescription,
            LongDescription)
    {

    }
}
