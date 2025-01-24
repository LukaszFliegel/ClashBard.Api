using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Ethereal : TowSpecialRule
{
    private static string ShortDescription = "Lacking physical bodies, some beings are immune to mundane weapons.";
    private static string LongDescription = "Ethereal creatures treat all terrain as open ground for the purposes of movement. They cannot end their movement inside impassable terrain, though they can pass through it. In addition, Ethereal creatures can only be wounded by Magical attacks. Characters that are not Ethereal cannot join units that are, and vice versa.";

    public Ethereal()
        : base(TowSpecialRuleType.Ethereal,
            ShortDescription,
            LongDescription)
    {

    }
}
