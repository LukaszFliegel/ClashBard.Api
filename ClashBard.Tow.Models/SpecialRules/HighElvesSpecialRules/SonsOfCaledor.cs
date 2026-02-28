using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class SonsOfCaledor : TowSpecialRule
{
    public SonsOfCaledor()
        : base(TowSpecialRuleType.SonsOfCaledor,
            "Sons of Caledor",
            "A unit with this special rule may only be joined by your army's General, or by a character with the Blood of Caledor Elven Honour.")
    {
    }
}
