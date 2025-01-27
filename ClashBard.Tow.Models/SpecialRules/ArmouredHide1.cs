using ClashBard.Tow.Models;
using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ArmouredHide1 : TowSpecialRule, ISaveImprover
{
    private static string ShortDescription = "Armour value + 1";
    private static string LongDescription = "The hide of some creatures forms natural armour and improves their armour value (and that of their rider). By how much armour value is improved varies from model to model, as shown in brackets after the name of this special rule (shown here as 'X').";

    public ArmouredHide1()
        : base(TowSpecialRuleType.ArmouredHide1,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }

    public int? MeleeSaveBaseline => null;

    public int MeleeSaveImprovement => 1;

    public int? RangedSaveBaseline => null;

    public int RangedSaveImprovement => 1;

    public bool AsteriskOnSave => false;
}
