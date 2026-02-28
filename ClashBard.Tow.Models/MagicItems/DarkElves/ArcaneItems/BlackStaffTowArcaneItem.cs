using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.ArcaneItems;

/// <summary>
/// A Black Staff is the talisman of the High Mistresses of the Convent of Sorceresses.
/// When casting, roll an extra D6 and discard the lowest. However, if a double 1 is rolled on any two dice, the spell is miscast.
/// 55 points.
/// </summary>
public class BlackStaffTowArcaneItem : TowArcaneItem
{
    private const int points = 55;

    public BlackStaffTowArcaneItem(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.BlackStaff, points)
    {
        AssignSpecialRule(new BlackStaffRules());
    }

    protected class BlackStaffRules : TowSpecialRule
    {
        private static string ShortDescription = "Casting: extra D6, discard lowest. Double 1 on any two dice = miscast";
        private static string LongDescription = "The bearer of the Black Staff may use it when attempting to cast a spell. If they do so, roll an extra D6 when making the Casting roll and discard the lowest result. However, if a double 1 is rolled on any two of the dice rolled, the spell is miscast.";

        public BlackStaffRules()
            : base(TowSpecialRuleType.BlackStaffRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
