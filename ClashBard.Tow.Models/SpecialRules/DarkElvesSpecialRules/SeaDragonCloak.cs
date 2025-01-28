using ClashBard.Tow.Models;
using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class SeaDragonCloak : TowSpecialRule, ISaveImprover
{
    private static string ShortDescription = "+1 save vs non-magical shooting";
    private static string LongDescription = "A model with this special rule improves its armour value by 1 (to a maximum of 2+) against non-magical shooting attacks.";

    public SeaDragonCloak()
        : base(TowSpecialRuleType.SeaDragonCloak,
            ShortDescription,
            LongDescription)
    {

    }

    public int? MeleeSaveBaseline => null;

    public int MeleeSaveImprovement => 0;

    public int? RangedSaveBaseline => null;

    public int RangedSaveImprovement => 1;

    public bool AsteriskOnSave => true;
}
