using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Factions.MagiItems;

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
}
