﻿using System.ComponentModel;

namespace ClashBard.Tow.Models.TowTypes;

public enum TowWeaponType
{
    [Description("Hand Weapon")]
    HandWeapon = 1,
    [Description("Additional Hand Weapon")]
    AdditionalHandWeapon,
    [Description("Great Weapon")]
    GreatWeapon,
    [Description("Flail")]
    Flail,
    [Description("Morningstar")]
    Morningstar,
    [Description("Halberd")]
    Halberd,
    [Description("Whip")]
    Whip,
    [Description("Lance")]
    Lance,
    [Description("Cavalry Spear")]
    CavalrySpear,
    [Description("Throwing Spear")]
    ThrowingSpear,
    [Description("Thrusting Spear")]
    ThrustingSpear,
    [Description("Shortbow")]
    Shortbow,
    [Description("Warbow")]
    Warbow,
    [Description("Longbow")]
    Longbow,
    [Description("Repeater Handbow")]
    RepeaterHandbow,
    [Description("Brace of Repeater Handbows")]
    BraceOfRepeaterHandbows,
    [Description("Crossbow")]
    Crossbow,
    [Description("Repeater Crossbow")]
    RepeaterCrossbow,
    [Description("Pistol")]
    Pistol,
    [Description("Brace of Pistols")]
    BraceOfPistols,
    [Description("Repeater Pistol")]
    RepeaterPistol,
    [Description("Handgun")]
    Handgun,
    [Description("Repeater Handgun")]
    RepeaterHandgun,
    [Description("Throwing Weapon")]
    ThrowingWeapon,
    [Description("Throwing Axe")]
    ThrowingAxe,
    [Description("Javelin")]
    Javelin,
    [Description("Sling")]
    Sling,
    //[Description("Other")]
    //Other
}