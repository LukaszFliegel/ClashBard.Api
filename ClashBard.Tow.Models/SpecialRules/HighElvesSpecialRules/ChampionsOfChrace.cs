using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class ChampionsOfChrace : TowSpecialRule
{
    private static readonly int pointsCost = 0;
    private static string ShortDescription = "Elite warriors of Chrace";
    private static string LongDescription = "The Lion Guard are the Champions of Chrace, elite warriors who serve as bodyguards to the Phoenix King.";

    public ChampionsOfChrace()
        : base(TowSpecialRuleType.ChampionsOfChrace,
              ShortDescription,
              LongDescription)
    {
    }
}
