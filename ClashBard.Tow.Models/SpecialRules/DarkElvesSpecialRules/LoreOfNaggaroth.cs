using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class LoreOfNaggaroth : TowSpecialRule
{
    private static string ShortDescription = "Lore of Naggaroth";
    private static string LongDescription = "A Wizard with the ‘Lore of Naggaroth’ special rule may discard one of their randomly generated spells as normal. When they do so, they may select instead either the signature spell of their chosen Lore of Magic, or one of the spells: Cursing Word, Black Horror";

    public LoreOfNaggaroth()
        : base(TowSpecialRuleType.LoreOfNaggaroth,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
