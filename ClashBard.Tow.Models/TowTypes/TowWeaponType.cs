using System.ComponentModel;
using System.Reflection;

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

    // Artillery
    [Description("Bolt Thrower")]
    BoltThrower,
    [Description("Repeater Bolt Thrower")]
    RepeaterBoltThrower,
    [Description("Repeater Bolt Thrower (Rapid Fire)")]
    RepeaterBoltThrowerRapidFire,
    [Description("Stone Thrower")]
    StoneThrower,
    [Description("Cannon")]
    Cannon,
    [Description("Great Cannon")]
    GreatCannon,
    [Description("Grapeshot")]
    Grapeshot,    
    [Description("Organ Gun")]
    OrganGun,
    [Description("Mortar")]
    Mortar,
    [Description("Fire Thrower")]
    FireThrower,

    // Dark Elves weapon types
    [Description("Dread Halberd")]
    DreadHalberd,
    [Description("Har Ganeth Greatsword")]
    HarGanethGreatsword,
    [Description("Lash & Buckler")]
    LashAndBuckler,
    [Description("Petrifying Gaze")]
    PetrifyingGaze,
    [Description("Wicked Claws")]
    WickedClaws,
    [Description("Serrated Maw")]
    SerratedMaw,
    [Description("Noxious Breath")]
    NoxiousBreath,
    [Description("Venomous Tail")]
    VenomousTail,
    [Description("Fiery Breath")]
    FieryBreath,
    [Description("Cavernous Maw")]
    CavernousMaw,
}

public static class TowWeaponTypeExtensions
{
    public static string ToDescriptionString(this TowWeaponType weaponType)
    {
        FieldInfo fi = weaponType.GetType().GetField(weaponType.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
        else
            return weaponType.ToString();
    }
}