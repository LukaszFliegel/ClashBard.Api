using ClashBard.Api.DTOs;
using ClashBard.Tow.Models;
using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.FactionModels.DarkElves;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.Factions.ArmyCompositions;
using ClashBard.Tow.Models.MagicItems.ArcaneItems;
using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.MagicItems.DarkElves.ArcaneItems;
using ClashBard.Tow.Models.MagicItems.DarkElves.EnchantedItems;
using ClashBard.Tow.Models.MagicItems.DarkElves.MagicArmours;
using ClashBard.Tow.Models.MagicItems.DarkElves.MagicWeapons;
using ClashBard.Tow.Models.MagicItems.DarkElves.Talismans;
using ClashBard.Tow.Models.MagicItems.EnchantedItems;
using ClashBard.Tow.Models.MagicItems.MagicArmours;
using ClashBard.Tow.Models.MagicItems.MagicBanners;
using ClashBard.Tow.Models.MagicItems.MagicWeapons;
using ClashBard.Tow.Models.MagicItems.Talismans;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;

namespace ClashBard.Api.Services;

public class DarkElvesCatalogProvider : FactionCatalogProviderBase
{
    public override TowFactionType FactionType => TowFactionType.DarkElves;

    private FactionCatalogDto? _cached;

    public override FactionCatalogDto BuildCatalog()
    {
        _cached ??= BuildDarkElvesCatalog();
        return _cached;
    }

    protected override Dictionary<string, Func<TowObject, TowModelCharacterMount>> GetCharacterMountFactories()
    {
        return new Dictionary<string, Func<TowObject, TowModelCharacterMount>>
        {
            ["DarkSteed"] = owner => new DarkSteedTowCharacterMount(owner),
            ["ColdOne"] = owner => new ColdOneTowCharacterMount(owner),
            ["DarkPegasus"] = owner => new DarkPegasusTowCharacterMount(owner),
            ["ColdOneChariot"] = owner => new ColdOneChariotsTowCharacterMount(owner),
            ["ScourgerunnerChariot"] = owner => new ScourgerunnerChariotTowCharacterMount(owner),
            ["BlackDragon"] = owner => new BlackDragonTowCharacterMount(owner),
            ["Manticore"] = owner => new ManticoreTowCharacterMount(owner),
            ["CauldronOfBlood"] = owner => new CauldronOfBloodTowCharacterMount(owner)
        };
    }

    private FactionCatalogDto BuildDarkElvesCatalog()
    {
        var faction = new DarkElvesTowFaction();
        var army = new TowArmy(faction, 2000, "catalog-dummy");
        var composition = new DarkElvesArmyComposition(army);

        var characters = BuildCharacterCatalog(army);
        var units = BuildUnitCatalog(army, composition);
        var magicItems = BuildMagicItemCatalog(army);
        var compositionRules = BuildCompositionRules();

        return new FactionCatalogDto(
            FactionType.ToSlug(),
            FactionType.ToNameString(),
            characters,
            units,
            magicItems,
            compositionRules
        );
    }

    private IReadOnlyList<CharacterCatalogDto> BuildCharacterCatalog(TowArmy army)
    {
        return new List<CharacterCatalogDto>
        {
            ExtractCharacter(new DarkElfDreadlordTowCharacter(army)),
            ExtractCharacter(new DarkElfMasterTowCharacter(army)),
            ExtractCharacter(new SupremeSorceressTowCharacter(army)),
            ExtractCharacter(new SorceressTowCharacter(army)),
            ExtractCharacter(new HighBeastmasterTowCharacter(army)),
            ExtractCharacter(new DeathHagTowCharacter(army)),
            ExtractCharacter(new KhainiteAssassinTowCharacter(army)),
        };
    }

    private IReadOnlyList<UnitModelCatalogDto> BuildUnitCatalog(TowArmy army, DarkElvesArmyComposition composition)
    {
        var units = new List<UnitModelCatalogDto>();

        // Core
        units.Add(ExtractUnit(new DarkElfWarriorTowModel(army), "Core"));
        units.Add(ExtractUnit(new RepeaterCrossbowmanTowModel(army), "Core"));
        units.Add(ExtractUnit(new BlackArkCorsairTowModel(army), "Core"));
        units.Add(ExtractUnit(new DarkRiderTowModel(army), "Core"));
        units.Add(ExtractUnit(new HarpyTowModel(army), "Core"));

        // Special
        units.Add(ExtractUnit(new BlackGuardOfNaggarondTowModel(army), "Special"));
        units.Add(ExtractUnit(new HarGanethExecutionerTowModel(army), "Special"));
        units.Add(ExtractUnit(new DarkElfShadeTowModel(army), "Special"));
        units.Add(ExtractUnit(new WitchElfTowModel(army), "Special"));
        units.Add(ExtractUnit(new SisterOfSlaughterTowModel(army), "Special"));
        units.Add(ExtractUnit(new ColdOneKnightTowModel(army), "Special"));
        units.Add(ExtractUnit(new DoomfireWarlockTowModel(army), "Special"));
        units.Add(ExtractUnit(new ColdOneChariotsTowModel(army), "Special"));
        units.Add(ExtractUnit(new ScourgerunnerChariotTowModel(army), "Special"));

        // Rare
        units.Add(ExtractUnit(new BloodwrackShrineTowModel(army), "Rare"));
        units.Add(ExtractUnit(new WarHydraTowModel(army), "Rare"));
        units.Add(ExtractUnit(new KharibdyssTowModel(army), "Rare"));
        units.Add(ExtractUnit(new ReaperBoltThrowerTowModel(army), "Rare"));

        return units;
    }

    private IReadOnlyList<MagicItemCatalogDto> BuildMagicItemCatalog(TowArmy army)
    {
        var items = new List<MagicItemCatalogDto>();
        var dummyOwner = new DarkElfDreadlordTowCharacter(army);

        // Common Magic Weapons
        items.Add(MagicItemDto(new OgreBladeTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new GiantBladeTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new SwordOfBattleTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new SwordOfMightTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new SwordOfStrikingTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new SwordOfSwiftnessTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new DuellistsBladesTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new DragonSlayingSwordTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new HeadsmansAxeTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new SpelleaterAxeTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new BerserkerBladeTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new BitingBladeTowMagicWeapon(dummyOwner), false));
        items.Add(MagicItemDto(new BurningBladeTowMagicWeapon(dummyOwner), false));

        // Common Magic Armours
        items.Add(MagicItemDto(new ArmourOfDestinyTowMagicArmour(dummyOwner), false));
        items.Add(MagicItemDto(new ArmourOfMeteoricIronTowMagicArmour(dummyOwner), false));
        items.Add(MagicItemDto(new ArmourOfSilveredSteelTowMagicArmour(dummyOwner), false));
        items.Add(MagicItemDto(new BedazzlingHelmTowMagicArmour(dummyOwner), false));
        items.Add(MagicItemDto(new CharmedShieldTowMagicArmour(dummyOwner), false));
        items.Add(MagicItemDto(new EnchantedShieldTowMagicArmour(dummyOwner), false));
        items.Add(MagicItemDto(new GlitteringScalesTowMagicArmour(dummyOwner), false));
        items.Add(MagicItemDto(new ShieldOfTheWarriorTrueTowMagicArmour(dummyOwner), false));
        items.Add(MagicItemDto(new SpellshieldTowMagicArmour(dummyOwner), false));

        // Common Talismans
        items.Add(MagicItemDto(new DawnstoneTowTalisman(dummyOwner), false));
        items.Add(MagicItemDto(new TalismanOfProtectionTowTalisman(dummyOwner), false));
        items.Add(MagicItemDto(new PaymastersCoinTowTalisman(dummyOwner), false));
        items.Add(MagicItemDto(new ObsidianLodestoneTowTalisman(dummyOwner), false));
        items.Add(MagicItemDto(new LuckstoneTowTalisman(dummyOwner), false));

        // Common Enchanted Items
        items.Add(MagicItemDto(new WizardingHatTowEnchantedItem(dummyOwner), false));
        items.Add(MagicItemDto(new FlyingCarpetTowEnchantedItem(dummyOwner), false));
        items.Add(MagicItemDto(new HealingPotionTowEnchantedItem(dummyOwner), false));
        items.Add(MagicItemDto(new RubyRingOfRuinTowEnchantedItem(dummyOwner), false));
        items.Add(MagicItemDto(new PotionOfStrengthTowEnchantedItem(dummyOwner), false));
        items.Add(MagicItemDto(new PotionOfToughnessTowEnchantedItem(dummyOwner), false));
        items.Add(MagicItemDto(new PotionOfSpeedTowEnchantedItem(dummyOwner), false));
        items.Add(MagicItemDto(new PotionOfFoolhardinessTowEnchantedItem(dummyOwner), false));

        // Common Arcane Items
        items.Add(MagicItemDto(new FeedbackScrollTowArcaneItem(dummyOwner), false));
        items.Add(MagicItemDto(new ScrollOfTransmogrificationTowArcaneItem(dummyOwner), false));
        items.Add(MagicItemDto(new WandOfJetTowArcaneItem(dummyOwner), false));
        items.Add(MagicItemDto(new LoreFamiliarTowArcaneItem(dummyOwner), false));
        items.Add(MagicItemDto(new PowerScrollTowArcaneItem(dummyOwner), false));
        items.Add(MagicItemDto(new DispelScrollTowArcaneItem(dummyOwner), false));
        items.Add(MagicItemDto(new ArcaneFamiliarTowArcaneItem(dummyOwner), false));
        items.Add(MagicItemDto(new EarthingRodTowArcaneItem(dummyOwner), false));

        // Common Magic Standards
        items.Add(MagicItemDto(new BannerOfIronResolveTowMagicBanner(dummyOwner), false));
        items.Add(MagicItemDto(new RazorStandardTowMagicBanner(dummyOwner), false));
        items.Add(MagicItemDto(new RampagingBannerTowMagicBanner(dummyOwner), false));
        items.Add(MagicItemDto(new TheBlazingBannerTowMagicBanner(dummyOwner), false));
        items.Add(MagicItemDto(new WarBannerTowMagicBanner(dummyOwner), false));

        // Dark Elves Faction Magic Items
        // Gifts of Khaine
        items.Add(MagicItemDto(new CryOfWarRuneOfKhaine(dummyOwner), true));
        items.Add(MagicItemDto(new RuneOfKhaineRuneOfKhaine(dummyOwner), true));
        items.Add(MagicItemDto(new WitchbrewRuneOfKhaine(dummyOwner), true));

        // Dark Elves Talismans
        items.Add(MagicItemDto(new PendantOfKhaelethTowTalisman(dummyOwner), true));

        // Dark Elves Arcane Items
        items.Add(MagicItemDto(new TomeOfFurionTowArcaneItem(dummyOwner), true));
        items.Add(MagicItemDto(new FocusFamiliarTowArcaneItem(dummyOwner, 0), true));

        // Dark Elves Magic Weapons
        items.Add(MagicItemDto(new ExecutionersAxeTowMagicWeapon(dummyOwner), true));
        items.Add(MagicItemDto(new SwordOfRuinTowMagicWeapon(dummyOwner), true));
        items.Add(MagicItemDto(new LifetakerTowMagicWeapon(dummyOwner), true));
        items.Add(MagicItemDto(new WhipOfAgonyTowMagicWeapon(dummyOwner), true));

        // Dark Elves Magic Armours
        items.Add(MagicItemDto(new ShieldOfGhrondTowMagicArmour(dummyOwner), true));
        items.Add(MagicItemDto(new BloodArmourTowMagicArmour(dummyOwner), true));

        // Dark Elves Talismans
        items.Add(MagicItemDto(new PearlOfInfiniteBlaknessTowTalisman(dummyOwner), true));

        // Dark Elves Enchanted Items
        items.Add(MagicItemDto(new BlackDragonEggTowEnchantedItem(dummyOwner), true));
        items.Add(MagicItemDto(new HydrasToothTowEnchantedItem(dummyOwner), true));
        items.Add(MagicItemDto(new GuidingEyeTowEnchantedItem(dummyOwner), true));

        // Dark Elves Arcane Items (Black Staff added)
        items.Add(MagicItemDto(new BlackStaffTowArcaneItem(dummyOwner), true));

        // Dark Elves Magic Standards
        items.Add(MagicItemDto(new BannerOfHarGanethTowMagicBanner(dummyOwner), true));
        items.Add(MagicItemDto(new ColdBloodedBannerTowMagicBanner(dummyOwner), true));
        items.Add(MagicItemDto(new BannerOfNagarytheTowMagicBanner(dummyOwner), true));
        items.Add(MagicItemDto(new StandardOfSlaughterTowMagicBanner(dummyOwner), true));

        // Dark Elves Forbidden Poisons (Assassin only)
        var assassin = new KhainiteAssassinTowCharacter(army);
        items.Add(MagicItemDto(new BlackLotusForbiddenPoison(assassin), true));
        items.Add(MagicItemDto(new DarkVenomForbiddenPoison(assassin), true));
        items.Add(MagicItemDto(new ManbaneForbiddenPoison(assassin), true));

        return items;
    }

    private static CompositionRulesDto BuildCompositionRules()
    {
        return new CompositionRulesDto(
            new List<SlotPercentageRuleDto>
            {
                new("Characters", null, 50),
                new("Core", 25, null),
                new("Special", null, 50),
                new("Rare", null, 25)
            },
            new List<string> { DarkElvesTowModelType.DarkElfMaster.ToString() }
        );
    }
}
