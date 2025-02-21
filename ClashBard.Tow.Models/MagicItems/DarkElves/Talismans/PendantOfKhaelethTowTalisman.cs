using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.Talismans;

public class PendantOfKhaelethTowTalisman : TowEnchantedItem, IWardSaveImprover
{
    private const int points = 40;


    public PendantOfKhaelethTowTalisman(TowObject owner) : base(owner, TowDarkElvesMagicItemType.PendantOfKhaeleth, points)
    {
        AssignSpecialRule(new PendantOfKhaelethRules());

    }

    public int? MeleeWardSaveBaseline => 5;

    public int MeleeWardSaveImprovement => 0;

    public int? RangedWardSaveBaseline => 5;

    public int RangedWardSaveImprovement => 0;

    public bool AsteriskOnWardSave => true;

    protected class PendantOfKhaelethRules : TowSpecialRule
    {
        private static string ShortDescription = "5+ WSv vs S<5, 4+ WSv vs S>=5";
        private static string LongDescription = "The Pendant of Khaeleth gives its bearer a 5+ Ward save against any wounds suffered that were caused by an attack with a Strength of 4 or lower, and a 4+ Ward save against any wounds suffered that were caused by an attack with a Strength of 5 or higher.";

        public PendantOfKhaelethRules()
            : base(TowSpecialRuleType.FlyingCarpetRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {

        }
    }
}



