using System.ComponentModel;

namespace ClashBard.Tow.Models.MagicItems.HighElves;

public enum TowHighElvesMagicItemType
{
    // Magic Weapons
    [Description("Star Lance")]
    StarLance,
    [Description("Blade of Leaping Gold")]
    BladeOfLeapingGold,
    [Description("Reaver Bow")]
    ReaverBow,
    [Description("Bow of the Seafarer")]
    BowOfTheSeafarer,

    // Magic Armour
    [Description("Dragon Armour of Aenarion")]
    DragonArmourOfAenarion,
    [Description("Golden Crown of Atrazar")]
    GoldenCrownOfAtrazar,
    [Description("Helm of Fortune")]
    HelmOfFortune,

    // Talismans
    [Description("Phoenix Stone")]
    PhoenixStone,
    [Description("Silvered Sceptre")]
    SilveredSceptre,
    [Description("Moranion's Wayshard")]
    MoranionsWayshard,

    // Arcane Items
    [Description("Book of Hoeth")]
    BookOfHoeth,
    [Description("Folariath's Robe")]
    FolariathsRobe,
    [Description("Seerstaff of Saphery")]
    SeerstaffOfSaphery,

    // Enchanted Items
    [Description("Radiant Gem of Hoeth")]
    RadiantGemOfHoeth,
    [Description("Horn of Isha")]
    HornOfIsha,
    [Description("Stone of Midnight")]
    StoneOfMidnight,

    // Magic Standards
    [Description("Banner of the World Dragon")]
    BannerOfTheWorldDragon,
    [Description("Gleaming Pennant")]
    GleamingPennant,
    [Description("Standard of Balance")]
    StandardOfBalance,
}
