using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.ArcaneItems;

public class FocusFamiliarTowArcaneItem : TowArcaneItem, IExtremelyCommon
{
    private const int points = 10;

    public FocusFamiliarTowArcaneItem(TowObject owner, int numberOfOccurences = 1) : base(owner, TowDarkElvesMagicItemType.FocusFamiliar, points)
    {
        AssignSpecialRule(new SingleUse());
        //AssignSpecialRule(new ExtremelyCommon(numberOfOccurences));
        AssignSpecialRule(new FocusFamiliarRules());
        NumberOfOccurences = numberOfOccurences;
    }

    public int NumberOfOccurences { get; }
}

public class FocusFamiliarRules : TowSpecialRule
{
    private static string ShortDescription = "Cast spells from familiar 12\" away";
    private static string LongDescription = "The owner of a Focus Familiar may use it when they attempt to cast a spell. Place a marker (such as a Familiar model) completely within 12\" of the owner. The range and all effects of the spell are measured from this marker, rather than from the owner. If the spell requires a line of sight, this is determined from the marker (which has a 360° vision arc).";

    public FocusFamiliarRules()
        : base(TowSpecialRuleType.FocusFamiliar,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}