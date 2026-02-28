using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.Talismans;

/// <summary>
/// Swirled with red and black veins, this magical pearl emits a soul-numbing aura.
/// The bearer and any unit they have joined gains the Immune to Psychology special rule.
/// 15 points.
/// </summary>
public class PearlOfInfiniteBlaknessTowTalisman : TowTalisman
{
    private const int points = 15;

    public PearlOfInfiniteBlaknessTowTalisman(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.PearlOfInfiniteBleakness, points)
    {
        AssignSpecialRule(new PearlOfInfiniteBleanessRules());
    }

    protected class PearlOfInfiniteBleanessRules : TowSpecialRule
    {
        private static string ShortDescription = "Bearer and unit: Immune to Psychology";
        private static string LongDescription = "The bearer of the Pearl of Infinite Bleakness and any unit they have joined gains the Immune to Psychology special rule.";

        public PearlOfInfiniteBleanessRules()
            : base(TowSpecialRuleType.PearlOfInfiniteBleanessRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
