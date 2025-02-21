using System.ComponentModel;

namespace ClashBard.Tow.Models.TowTypes;

public enum TowMagicItemCategory
{
    [Description("Magic Weapon")]
    MagicWeapon,
    [Description("Magic Armor")]
    MagicArmour,
    [Description("Magic Banner")]
    MagicStandard,
    [Description("Enchanted Ttem")]
    EnchantedItem,
    [Description("Talisman")]
    Talisman,
    [Description("Arcane")]
    Arcane,

    //[Description("Faction specific")]
    //FactionSpecific,
    [Description("Faction specific print as weapon")]
    FactionSpecificPrintAsWeapon,

    // Dark Elves
    [Description("Gifts of Khaine")]
    GiftsOfKhaine,
}

public enum TowMagicItemWeaponType
{
    [Description("Ogre Blade")]
    OgreBlade,
    [Description("Sword of Battle")]
    SwordOfBattle,
    [Description("Duellist's Blades")]
    DuellistsBlades,
    [Description("Dragon Slaying Sword")]
    DragonSlayingSword,
    [Description("Headsman's Axe")]
    HeadsmansAxe,
    [Description("Spelleater Axe")]
    SpelleaterAxe,
    [Description("Giant Blade")]
    GiantBlade,
    [Description("Sword of Swiftness")]
    SwordOfSwiftness,
    [Description("Berserker Blade")]
    BerserkerBlade,
    [Description("Sword of Might")]
    SwordOfMight,
    [Description("Biting Blade")]
    BitingBlade,
    [Description("Sword of Striking")]
    SwordOfStriking,
    [Description("Burning Blade")]
    BurningBlade
}

public enum TowMagicItemArmorType
{
    [Description("Armour of Destiny")]
    ArmourOfDestiny,
    [Description("Bedazzling Helm")]
    BedazzlingHelm,
    [Description("Armour of Silvered Steel")]
    ArmourOfSilveredSteel,
    [Description("Glittering Scales")]
    GlitteringScales,
    [Description("Shield of the Warrior True")]
    ShieldOfTheWarriorTrue,
    [Description("Spellshield")]
    Spellshield,
    [Description("Armour of Meteoric Iron")]
    ArmourOfMeteoricIron,
    [Description("Enchanted Shield")]
    EnchantedShield,
    [Description("Charmed Shield")]
    CharmedShield
}

public enum TowMagicItemBannerType
{
    [Description("Banner of Iron Resolve")]
    BannerOfIronResolve,
    [Description("Razor Standard")]
    RazorStandard,
    [Description("Rampaging Banner")]
    RampagingBanner,
    [Description("The Blazing Banner")]
    TheBlazingBanner,
    [Description("War Banner")]
    WarBanner
}

public enum TowMagicItemEnchantedType
{
    [Description("Wizarding Hat")]
    WizardingHat,
    [Description("Flying Carpet")]
    FlyingCarpet,
    [Description("Healing Potion")]
    HealingPotion,
    [Description("Ruby Ring of Ruin")]
    RubyRingOfRuin,
    [Description("Potion of Strength")]
    PotionOfStrength,
    [Description("Potion of Toughness")]
    PotionOfToughness,
    [Description("Potion of Speed")]
    PotionOfSpeed,
    [Description("Potion of Foolhardiness")]
    PotionOfFoolhardiness
}

public enum TowMagicItemArcaneType
{
    [Description("Feedback Scroll")]
    FeedbackScroll,
    [Description("Scroll of Transmogrification")]
    ScrollOfTransmogrification,
    [Description("Wand of Jet")]
    WandOfJet,
    [Description("Lore Familiar")]
    LoreFamiliar,
    [Description("Power Scroll")]
    PowerScroll,
    [Description("Dispel Scroll")]
    DispelScroll,
    [Description("Arcane Familiar")]
    ArcaneFamiliar,
    [Description("Earthing Rod")]
    EarthingRod
}

public enum TowMagicItemTalismanType
{
    [Description("Dawnstone")]
    Dawnstone,
    [Description("Talisman of Protection")]
    TalismanOfProtection,
    [Description("Paymaster's Coin")]
    PaymastersCoin,
    [Description("Obsidian Lodestone")]
    ObsidianLodestone,
    [Description("Luckstone")]
    Luckstone
}