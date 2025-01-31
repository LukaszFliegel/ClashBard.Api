using System.ComponentModel;
using System.Reflection;

namespace ClashBard.Tow.Models.TowTypes;

public enum TowMagicLoreType
{
    [Description("Lore of Beasts")]
    LoreOfBeasts = 1,
    [Description("Lore of Hashut")]
    LoreOfHashut,
    [Description("Lore of Daemons")]
    LoreOfDaemons,
    [Description("Lore of Naggaroth")]
    LoreOfNaggaroth,
    [Description("Lore of Saphery")]
    LoreOfSaphery,
    [Description("Lore of the Lady")]
    LoreOfTheLady,
    [Description("Lore of Lustria")]
    LoreOfLustria,
    [Description("Lore of the Great Maw")]
    LoreOfTheGreatMaw,
    [Description("Lore of Gork")]
    LoreOfGork,
    [Description("Lore of Mork")]
    LoreOfMork,
    [Description("Lore of Troll Magic")]
    LoreOfTrollMagic,
    [Description("Lore of the Horned Rat")]
    LoreOfTheHornedRat,
    [Description("Lore of Nehekhara")]
    LoreOfNehekhara,
    [Description("Lore of Undeath")]
    LoreOfUndeath,
    [Description("Lore of Chaos")]
    LoreOfChaos,
    [Description("Lore of Athel Loren")]
    LoreOfAthelLoren,

    [Description("Battle Magic")]
    BattleMagic,
    [Description("Daemonology")]
    Daemonology,
    [Description("Dark Magic")]
    DarkMagic,
    [Description("Elementalism")]
    Elementalism,
    [Description("High Magic")]
    HighMagic,
    [Description("Illusion")]
    Illusion,
    [Description("Necromancy")]
    Necromancy,
    [Description("Waaagh! Magic")]
    WaaaghMagic,
}
