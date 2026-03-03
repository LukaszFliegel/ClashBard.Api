using System.Text.RegularExpressions;

namespace ClashBard.Tow.Models.TowTypes;

/// <summary>
/// Extension methods for converting <see cref="TowFactionType"/> to and from
/// URL-friendly slug strings (e.g. <c>DarkElves</c> ↔ <c>"dark-elves"</c>).
/// </summary>
public static partial class TowFactionTypeExtensions
{
    /// <summary>
    /// Converts a <see cref="TowFactionType"/> value to a lowercase
    /// hyphen-separated slug, e.g. <c>DarkElves</c> → <c>"dark-elves"</c>.
    /// Special cases are handled explicitly (e.g. OrcAndGoblinTribes → "orc-and-goblin-tribes").
    /// </summary>
    public static string ToSlug(this TowFactionType faction)
    {
        return faction switch
        {
            TowFactionType.EmpireOfMan          => "empire-of-man",
            TowFactionType.OrcAndGoblinTribes    => "orc-and-goblin-tribes",
            TowFactionType.DwarfenMountainHolds  => "dwarfen-mountain-holds",
            TowFactionType.WarriorsOfChaos       => "warriors-of-chaos",
            TowFactionType.KingdomOfBretonnia    => "kingdom-of-bretonnia",
            TowFactionType.BeastmenBrayherds     => "beastmen-brayherds",
            TowFactionType.WoodElves             => "wood-elf-realms",
            TowFactionType.TombKingsOfKhemri     => "tomb-kings-of-khemri",
            TowFactionType.HighElves             => "high-elf-realms",
            TowFactionType.DarkElves             => "dark-elves",
            TowFactionType.Skaven                => "skaven",
            TowFactionType.VampireCounts         => "vampire-counts",
            TowFactionType.DaemonsOfChaos        => "daemons-of-chaos",
            TowFactionType.OgreKingdoms          => "ogre-kingdoms",
            TowFactionType.Lizardmen             => "lizardmen",
            TowFactionType.ChaosDwarfs           => "chaos-dwarfs",
            TowFactionType.GrandCathay           => "grand-cathay",
            _ => throw new ArgumentOutOfRangeException(nameof(faction), faction, "Unknown faction type")
        };
    }

    /// <summary>
    /// Parses a slug string (e.g. <c>"dark-elves"</c>) into a <see cref="TowFactionType"/>
    /// value. Returns <c>null</c> if the slug does not match any known faction.
    /// </summary>
    public static TowFactionType? FromSlug(string slug)
    {
        return slug switch
        {
            "empire-of-man"          => TowFactionType.EmpireOfMan,
            "orc-and-goblin-tribes"  => TowFactionType.OrcAndGoblinTribes,
            "dwarfen-mountain-holds" => TowFactionType.DwarfenMountainHolds,
            "warriors-of-chaos"      => TowFactionType.WarriorsOfChaos,
            "kingdom-of-bretonnia"   => TowFactionType.KingdomOfBretonnia,
            "beastmen-brayherds"     => TowFactionType.BeastmenBrayherds,
            "wood-elf-realms"        => TowFactionType.WoodElves,
            "tomb-kings-of-khemri"   => TowFactionType.TombKingsOfKhemri,
            "high-elf-realms"        => TowFactionType.HighElves,
            "dark-elves"             => TowFactionType.DarkElves,
            "skaven"                 => TowFactionType.Skaven,
            "vampire-counts"         => TowFactionType.VampireCounts,
            "daemons-of-chaos"       => TowFactionType.DaemonsOfChaos,
            "ogre-kingdoms"          => TowFactionType.OgreKingdoms,
            "lizardmen"              => TowFactionType.Lizardmen,
            "chaos-dwarfs"           => TowFactionType.ChaosDwarfs,
            "grand-cathay"           => TowFactionType.GrandCathay,
            _ => null
        };
    }
}
