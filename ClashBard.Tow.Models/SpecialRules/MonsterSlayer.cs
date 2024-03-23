using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MonsterSlayer : TowSpecialRule
{
    private static new string ShortDescription = "Legends tell of warriors so mighty they can slay terrible monsters with but a single blow!";
    private static new string LongDescription = "If a model with this special rule rolls a natural 6 when making a roll To Wound for an attack made in combat, it has struck a 'Monster Slaying Blow'. Enemy models whose troop type is monster are not permitted an armour or Regeneration save against a Monster Slaying Blow (Ward saves can be attempted as normal). If an enemy model whose troop type is monster suffers an unsaved wound from a Monster Slaying Blow, it loses all of its remaining Wounds. Note that if an attack wounds automatically, this special rule cannot be used.";

    public MonsterSlayer()
        : base(TowSpecialRuleType.MonsterSlayer,
            ShortDescription,
            LongDescription)
    {

    }
}
