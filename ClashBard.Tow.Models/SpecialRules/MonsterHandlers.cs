using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MonsterHandlers : TowSpecialRule
{
    private static new string ShortDescription = "Colossal beasts are goaded into battle by beastmasters hurrying at their heels.";
    private static new string LongDescription = "A monster with this special rule is accompanied by one or more models representing its handlers. During deployment, position these models anywhere that is adjacent to, and in base contact with, the monster. If the handlers are found to be blocking movement or line of sight, simply move them aside. In combat, each handler adds its attacks to those of the monster. If the monster suffers an unsaved wound, roll a D6. On a roll of 1-4 the monster loses a Wound, but on a roll of 5+ a handler model suffers the wound instead. If the monster is removed from play, so are its handlers.";

    public MonsterHandlers()
        : base(TowSpecialRuleType.MonsterHandlers,
            ShortDescription,
            LongDescription)
    {

    }
}
