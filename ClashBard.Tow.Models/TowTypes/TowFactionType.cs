using System.ComponentModel;

namespace ClashBard.Tow.Models.TowTypes;

public enum TowFactionType
{
    [Description("Empire of Man")]
    EmpireOfMan,
    [Description("Orc & Goblin Tribes")]
    OrcAndGoblinTribes,
    [Description("Dwarfen Mountain Holds")]
    DwarfenMountainHolds,
    [Description("Warriors of Chaos")]
    WarriorsOfChaos,
    [Description("Kingdom of Bretonnia")]
    KingdomOfBretonnia,
    [Description("Beastmen Brayherds")]
    BeastmenBrayherds,
    [Description("Wood Elves")]
    WoodElves,
    [Description("Tomb Kings of Khemri")]
    TombKingsOfKhemri,
    [Description("High Elves")]
    HighElves,
    [Description("Dark Elves")]
    DarkElves,
    [Description("Skaven")]
    Skaven,
    [Description("Vampire Counts")]
    VampireCounts,
    [Description("Daemons of Chaos")]
    DaemonsOfChaos,
    [Description("Ogre Kingdoms")]
    OgreKingdoms,
    [Description("Lizardmen")]
    Lizardmen,
    [Description("Chaos Dwarfs")]
    ChaosDwarfs,
}