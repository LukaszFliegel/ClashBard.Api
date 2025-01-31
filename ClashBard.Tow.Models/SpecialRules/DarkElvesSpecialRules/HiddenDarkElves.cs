using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class HiddenDarkElves : TowSpecialRule
{
    private static string ShortDescription = "Not deployed but hides in one of the infantry unit (excluding harpies), can't be general";
    private static string LongDescription = "Khainite Assassins are not placed on the battlefield at the start of the game. Instead, they are 'hidden' within a friendly Dark Elf unit whose troop type is infantry and that has a Unit Strength of ten or more (excluding Harpies). Make a note of which unit each Assassin is hiding within. A hidden Assassin may be revealed during any Start of Turn sub-phase or at the start of any Combat phase. Position the revealed Assassin as you would a character that has joined the unit. If a unit in which a Khainite Assassin is hiding is destroyed or flees the battlefield before the Assassin is revealed, the Assassin is removed as a casualty. A Khainite Assassin cannot be your army General.";

    public HiddenDarkElves()
        : base(TowSpecialRuleType.HiddenDarkElves,
            ShortDescription,
            LongDescription)
    {

    }
}
