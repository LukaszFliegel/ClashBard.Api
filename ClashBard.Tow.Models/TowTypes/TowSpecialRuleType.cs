using System.ComponentModel;

namespace ClashBard.Tow.Models.TowTypes;

public enum TowSpecialRuleType
{
    [Description("Ambushers")]
    Ambushers = 1,
    [Description("Armour Bane (1)")]
    ArmourBane1,
    [Description("Armour Bane (2)")]
    ArmourBane2,
    [Description("Armour Bane (3)")]
    ArmourBane3,
    [Description("Breath Weapon")]
    BreathWeapon,
    [Description("Chariot Runners")]
    ChariotRunners,
    [Description("Close Order")]
    CloseOrder,
    [Description("Counter Charge")]
    CounterCharge,
    [Description("Cumbersome")]
    Cumbersome,
    [Description("Detachment")]
    Detachment,
    [Description("Dragged Along")]
    DraggedAlong,
    [Description("Drilled")]
    Drilled,
    [Description("Ethereal")]
    Ethereal,
    [Description("Evasive")]
    Evasive,
    [Description("Extra Attacks (+1)")]
    ExtraAttacksPlus1,
    [Description("Extra Attacks (+2)")]
    ExtraAttacksPlus2,
    [Description("Extra Attacks (+3)")]
    ExtraAttacksPlus3,
    [Description("Extra Attacks (+4)")]
    ExtraAttacksPlus4,
    [Description("Fast Cavalry")]
    FastCavalry,
    [Description("Fear")]
    Fear,
    [Description("Feigned Flight")]
    FeignedFlight,
    [Description("Fight in Extra Rank")]
    FightInExtraRank,
    [Description("Fight in Extra Rank any turn they did not charge")]
    FightinExtraRankanyturntheydidnotcharge,
    [Description("Fight in Extra Rank on turn user charged")]
    FightinExtraRankonturnusercharged,
    [Description("Fire & Flee")]
    FireAndFlee,
    [Description("First Charge")]
    FirstCharge,
    [Description("Flaming Attacks")]
    FlamingAttacks,
    [Description("Flammable")]
    Flammable,
    [Description("Fly (X)")]
    FlyX,
    [Description("Frenzy")]
    Frenzy,
    [Description("Furious Charge")]
    FuriousCharge,
    [Description("Hatred (X)")]
    HatredX,
    [Description("Horde")]
    Horde,
    [Description("Howdah")]
    Howdah,
    [Description("Ignores Cover")]
    IgnoresCover,
    [Description("Immune to Psychology")]
    ImmunetoPsychology,
    [Description("Impact Hits (X)")]
    ImpactHitsX,
    [Description("Impetuous")]
    Impetuous,
    [Description("Killing Blow")]
    KillingBlow,
    [Description("Large Target")]
    LargeTarget,
    [Description("Levies")]
    Levies,
    [Description("Loner")]
    Loner,
    [Description("Magical Attacks")]
    MagicalAttacks,
    [Description("Magic Resistance (-1)")]
    MagicResistance1,
    [Description("Magic Resistance (-2)")]
    MagicResistance2,
    [Description("Magic Resistance (-3)")]
    MagicResistance3,
    [Description("Mercenaries")]
    Mercenaries,
    [Description("Monster Handlers")]
    MonsterHandlers,
    [Description("Monster Slayer")]
    MonsterSlayer,
    [Description("Motley Crew")]
    MotleyCrew,
    [Description("Move & Shoot")]
    MoveAndShoot,
    [Description("Move or Shoot")]
    MoveOrShoot,
    [Description("Move Through Cover")]
    MoveThroughCover,
    [Description("Multiple Shots (2)")]
    MultipleShots2,
    [Description("Multiple Shots (3)")]
    MultipleShots3,
    [Description("Multiple Shots (4)")]
    MultipleShots4,
    [Description("Multiple Wounds (2)")]
    MultipleWounds2,
    [Description("Multiple Wounds (3)")]
    MultipleWounds3,
    [Description("Multiple Wounds (4)")]
    MultipleWounds4,
    [Description("Open Order")]
    OpenOrder,
    [Description("Poisoned Attacks")]
    PoisonedAttacks,
    [Description("Ponderous")]
    Ponderous,
    [Description("Quick Shot")]
    QuickShot,
    [Description("Rallying Cry")]
    RallyingCry,
    [Description("Random Attacks")]
    RandomAttacks,
    [Description("Random Movement")]
    RandomMovement,
    [Description("Regeneration (X+)")]
    RegenerationXPlus,
    [Description("Regimental Unit")]
    RegimentalUnit,
    [Description("Requires Two Hands")]
    RequiresTwoHands,
    [Description("Reserve Move")]
    ReserveMove,
    [Description("Scouts")]
    Scouts,
    [Description("Shieldwall")]
    Shieldwall,
    [Description("Skirmishers")]
    Skirmishers,
    [Description("Stomp Attacks (X)")]
    StompAttacksX,
    [Description("Strike First")]
    StrikeFirst,
    [Description("Strike Last")]
    StrikeLast,
    [Description("Stubborn")]
    Stubborn,
    [Description("Stupidity")]
    Stupidity,
    [Description("Swiftstride")]
    Swiftstride,
    [Description("Terror")]
    Terror,
    [Description("Timmm-berrr!")]
    Timmmberrr,
    [Description("Unbreakable")]
    Unbreakable,
    [Description("Unstable")]
    Unstable,
    [Description("Vanguard")]
    Vanguard,
    [Description("Veteran")]
    Veteran,
    [Description("Volley Fire")]
    VolleyFire,
    [Description("Warband")]
    Warband,
    [Description("Warp-spawned")]
    WarpSpawned,
    [Description("S+1 first round of combat only")]
    SPlus1FirstRoundOfCombat,
    [Description("S+2 first round of combat only")]
    SPlus2FirstRoundOfCombat,
    [Description("Turn user charged only")]
    TurnUserCharged,
    [Description("S and AP only on turn user charged")]
    SandAPTurnUserCharged,

    // Dark Evles

    [Description("Cleaving Blow")]
    CleavingBlow,
    [Description("Elven Reflexes")]
    ElvenReflexes,
    [Description("Eternal Hatred")]
    EternalHatred,
    [Description("Hekarti's Blessing")]
    HekartisBlessing,
    [Description("Martial Prowess")]
    MartialProwess,
    [Description("Murderous")]
    Murderous,
    [Description("Goad Beast")]
    GoadBeast,
    [Description("Sea Dragon Cloak")]
    SeaDragonCloak,
}