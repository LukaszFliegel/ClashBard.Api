using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.MagicItems.DarkElves;

public enum TowDarkElfMagicItemType
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
}
