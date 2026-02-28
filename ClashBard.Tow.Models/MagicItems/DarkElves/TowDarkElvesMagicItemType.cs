using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.MagicItems.DarkElves;

public enum TowDarkElvesMagicItemType
{
    // Gifts Of Khaine
    [Description("Cry of War")]
    CryOfWar,
    [Description("Rune of Khaine")]
    RuneOfKhaine,
    [Description("Witchbrew")]
    Witchbrew,

    // Blessings Of Khaine
    [Description("Fury of Khaine")]
    FuryOfKhaine,
    [Description("Strength of Khaine")]
    StrengthOfKhaine,
    [Description("Bloodshield of Khaine")]
    BloodshieldOfKhaine,

    // Forbidden poisins
    [Description("Black Lotus")]
    BlackLotus,
    [Description("Dark Venom")]
    DarkVenom,
    [Description("Manbane")]
    Manbane,

    // Talismans
    [Description("Pendant of Khaeleth")]
    PendantOfKhaeleth,

    // Arcane Items
    [Description("Tome of Furion")]
    TomeOfFurion,
    [Description("Focus Familiar")]
    FocusFamiliar,

    // Talismans
    [Description("Pearl of Infinite Bleakness")]
    PearlOfInfiniteBleakness,

    // Magic Weapons
    [Description("Executioner's Axe")]
    ExecutionersAxe,
    [Description("Sword of Ruin")]
    SwordOfRuin,
    [Description("Lifetaker")]
    Lifetaker,
    [Description("Whip of Agony")]
    WhipOfAgony,

    // Magic Armours
    [Description("Shield of Ghrond")]
    ShieldOfGhrond,
    [Description("Blood Armour")]
    BloodArmour,

    // Enchanted Items
    [Description("Black Dragon Egg")]
    BlackDragonEgg,
    [Description("Hydra's Tooth")]
    HydrasTooth,
    [Description("The Guiding Eye")]
    GuidingEye,

    // Arcane Items
    [Description("Black Staff")]
    BlackStaff,

    // Banners
    [Description("Banner Of Har Ganeth")]
    BannerOfHarGaneth,
    [Description("Cold-Blooded Banner")]
    ColdBloodedBanner,
    [Description("Banner of Nagarythe")]
    BannerOfNagarythe,
    [Description("Standard of Slaughter")]
    StandardOfSlaughter,
}
