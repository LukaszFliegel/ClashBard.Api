using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Terror : TowSpecialRule
{
    private static new string ShortDescription = "There are creatures so fierce that their mere appearance can cause the bravest to flee.";
    private static new string LongDescription = "Models with this special rule cause Terror. Models that cause Terror also cause Fear: When a unit that causes Terror declares a charge, the charge target must immediately make a Leadership test. If this test is failed, it must Flee. If this test is passed, it can declare its charge reaction normally. If the winning side of a combat includes one or more units that cause Terror, each unit that belongs to the losing side must apply a -1 modifier to its Leadership characteristic when making its Break test. Note that if a charged unit cannot choose to Flee, it does not make this Leadership test. Models with the Fear special rule Fear models that cause Terror. Models that cause Terror are immune to Terror. A unit that does not cause Terror does not become immune to Terror when joined by a character that does.";

    public Terror()
        : base(TowSpecialRuleType.Terror,
            ShortDescription,
            LongDescription)
    {

    }
}
