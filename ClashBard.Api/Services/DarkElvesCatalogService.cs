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

public class DarkElvesCatalogService : ICatalogService
{
    private FactionCatalogDto? _cachedCatalog;

    public IReadOnlyList<FactionSummaryDto> GetFactions()
    {
        return new List<FactionSummaryDto>
        {
            new("dark-elves", TowFactionType.DarkElves.ToNameString())
        };
    }

    public FactionCatalogDto? GetFactionCatalog(string factionId)
    {
        if (factionId != "dark-elves") return null;

        _cachedCatalog ??= BuildDarkElvesCatalog();
        return _cachedCatalog;
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
            "dark-elves",
            TowFactionType.DarkElves.ToNameString(),
            characters,
            units,
            magicItems,
            compositionRules
        );
    }

    private IReadOnlyList<CharacterCatalogDto> BuildCharacterCatalog(TowArmy army)
    {
        var characters = new List<CharacterCatalogDto>();

        // Instantiate each character type, extract metadata
        characters.Add(ExtractCharacter(new DarkElfDreadlordTowCharacter(army)));
        characters.Add(ExtractCharacter(new DarkElfMasterTowCharacter(army)));
        characters.Add(ExtractCharacter(new SupremeSorceressTowCharacter(army)));
        characters.Add(ExtractCharacter(new SorceressTowCharacter(army)));
        characters.Add(ExtractCharacter(new HighBeastmasterTowCharacter(army)));
        characters.Add(ExtractCharacter(new DeathHagTowCharacter(army)));
        characters.Add(ExtractCharacter(new KhainiteAssassinTowCharacter(army)));

        return characters;
    }

    private CharacterCatalogDto ExtractCharacter(TowCharacter character)
    {
        var stats = new ModelStatsDto(
            character.Movement, character.WeaponSkill, character.BallisticSkill,
            character.Strength, character.Toughness, character.Wounds,
            character.Initiative, character.Attacks, character.Leadership
        );

        // Default weapons = weapons with cost 0 in AvailableWeapons that are already equipped
        var equippedWeaponTypes = character.GetWeapons(false).Select(w => w.WeaponType).ToHashSet();
        var defaultWeapons = character.AvailableWeapons
            .Where(w => w.Item2 == 0 && equippedWeaponTypes.Contains(w.Item1) && w.Item1.ToString() != "HandWeapon")
            .Select(w => new CatalogOptionDto(w.Item1.ToString()!, w.Item1.ToNameString(), w.Item2))
            .ToList();

        var availableWeapons = character.AvailableWeapons
            .Where(w => w.Item2 > 0)
            .Select(w => new CatalogOptionDto(w.Item1.ToString()!, w.Item1.ToNameString(), w.Item2))
            .ToList();

        var equippedArmourTypes = character.GetArmours().Select(a => a.ArmorType).ToHashSet();
        var defaultArmours = character.AvailableArmours
            .Where(a => a.Item2 == 0 && equippedArmourTypes.Contains(a.Item1))
            .Select(a => new CatalogOptionDto(a.Item1.ToString()!, a.Item1.ToNameString(), a.Item2))
            .ToList();

        var availableArmours = character.AvailableArmours
            .Where(a => a.Item2 > 0)
            .Select(a => new CatalogOptionDto(a.Item1.ToString()!, a.Item1.ToNameString(), a.Item2))
            .ToList();

        var availableSpecialRules = character.AvailableSpecialRules
            .Select(r => new CatalogOptionDto(r.Item1.ToString()!, r.Item1.ToNameString(), r.Item2))
            .ToList();

        var availableMounts = ExtractMounts(character, army: null);

        var availableMagicItemCategories = GetAvailableMagicItemCategories(character);

        MageInfoDto? mageInfo = null;
        if (character is TowCharacterMage mage)
        {
            mageInfo = ExtractMageInfo(mage);
        }

        BsbInfoDto? bsbInfo = null;
        if (character is TowCharacterBsb bsb)
        {
            bsbInfo = ExtractBsbInfo(bsb);
        }

        return new CharacterCatalogDto(
            character.ModelType.ToString()!,
            character.ModelType.ToNameString(),
            character.PointCost,
            stats,
            character.ModelTroopType.ToNameString(),
            defaultWeapons,
            availableWeapons,
            defaultArmours,
            availableArmours,
            availableSpecialRules,
            availableMounts,
            availableMagicItemCategories,
            character.MayBuyMagicItemsUpToPoints,
            mageInfo,
            bsbInfo
        );
    }

    private IReadOnlyList<MountCatalogDto> ExtractMounts(TowCharacter character, TowArmy? army)
    {
        // Build mount catalog from available mounts by instantiating each
        var mounts = new List<MountCatalogDto>();
        var mountFactories = GetCharacterMountFactories();

        // Use reflection to access protected AvailableMounts
        var availMountsField = typeof(TowModel).GetProperty("AvailableMounts",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        // AvailableMounts is protected, try field
        var availMountsFieldInfo = typeof(TowModel).GetField("AvailableMounts",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        // Use the property (it's protected set)
        var propInfo = typeof(TowModel).GetProperty("AvailableMounts",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);

        ICollection<(Enum, int)>? availableMounts = null;
        if (propInfo != null)
        {
            availableMounts = propInfo.GetValue(character) as ICollection<(Enum, int)>;
        }

        if (availableMounts == null) return mounts;

        foreach (var (mountType, cost) in availableMounts)
        {
            var mountId = mountType.ToString()!;
            if (mountFactories.TryGetValue(mountId, out var factory))
            {
                try
                {
                    var mount = factory(character);
                    var stats = new ModelStatsDto(
                        mount.Movement, mount.WeaponSkill, mount.BallisticSkill,
                        mount.Strength, mount.Toughness, mount.Wounds,
                        mount.Initiative, mount.Attacks, mount.Leadership
                    );
                    mounts.Add(new MountCatalogDto(
                        mountId,
                        mountType.ToNameString(),
                        cost,
                        stats,
                        mount.ModelTroopType.ToNameString(),
                        mount.ArmorValue,
                        mount.ToughnessAdded,
                        mount.WoundsAdded
                    ));
                }
                catch
                {
                    // If mount can't be instantiated (e.g. missing factory), add basic info
                    mounts.Add(new MountCatalogDto(mountId, mountType.ToNameString(), cost, null, "", null, null, null));
                }
            }
            else
            {
                mounts.Add(new MountCatalogDto(mountId, mountType.ToNameString(), cost, null, "", null, null, null));
            }
        }

        return mounts;
    }

    private List<string> GetAvailableMagicItemCategories(TowCharacter character)
    {
        // Access AvailableMagicItemTypes via reflection
        var field = typeof(TowCharacter).GetField("AvailableMagicItemTypes",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        if (field?.GetValue(character) is ICollection<TowMagicItemCategory> categories)
        {
            return categories.Select(c => c.ToString()!).ToList();
        }

        return new List<string>();
    }

    private MageInfoDto ExtractMageInfo(TowCharacterMage mage)
    {
        // Access protected members via reflection
        var baseLevelProp = typeof(TowCharacterMage).GetProperty("MagicLevel",
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        int baseLevel = mage.MagicLevel;

        var levelsField = typeof(TowCharacterMage).GetProperty("AvailableMagicLevels",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var availLevels = new List<CatalogOptionDto>();
        if (levelsField?.GetValue(mage) is ICollection<(TowMagicLevelType, int)> levels)
        {
            foreach (var (level, cost) in levels)
            {
                availLevels.Add(new CatalogOptionDto(level.ToString(), level.ToNameString(), cost));
            }
        }

        var loresField = typeof(TowCharacterMage).GetProperty("AvailableMagicLoreTypes",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var availLores = new List<CatalogOptionDto>();
        if (loresField?.GetValue(mage) is ICollection<TowMagicLoreType> lores)
        {
            foreach (var lore in lores)
            {
                availLores.Add(new CatalogOptionDto(lore.ToString(), lore.ToNameString(), 0));
            }
        }

        return new MageInfoDto(baseLevel, availLevels, availLores);
    }

    private BsbInfoDto ExtractBsbInfo(TowCharacterBsb bsb)
    {
        var upgradeCostField = typeof(TowCharacterBsb).GetField("battleStandardBearerUpgradeCost",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        int upgradeCost = (int)(upgradeCostField?.GetValue(bsb) ?? 0);

        var magicStdField = typeof(TowCharacterBsb).GetField("magicStandardUpToPoints",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        int magicStdAllowance = (int)(magicStdField?.GetValue(bsb) ?? 0);

        return new BsbInfoDto(upgradeCost, magicStdAllowance);
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

    private UnitModelCatalogDto ExtractUnit(TowModel model, string slotType)
    {
        var stats = new ModelStatsDto(
            model.Movement, model.WeaponSkill, model.BallisticSkill,
            model.Strength, model.Toughness, model.Wounds,
            model.Initiative, model.Attacks, model.Leadership
        );

        var equippedWeaponTypes = model.GetWeapons(false).Select(w => w.WeaponType).ToHashSet();
        var defaultWeapons = model.AvailableWeapons
            .Where(w => w.Item2 == 0 && equippedWeaponTypes.Contains(w.Item1) && w.Item1.ToString() != "HandWeapon")
            .Select(w => new CatalogOptionDto(w.Item1.ToString()!, w.Item1.ToNameString(), w.Item2))
            .ToList();

        var availableWeapons = model.AvailableWeapons
            .Where(w => w.Item2 > 0)
            .Select(w => new CatalogOptionDto(w.Item1.ToString()!, w.Item1.ToNameString(), w.Item2))
            .ToList();

        var equippedArmourTypes = model.GetArmours().Select(a => a.ArmorType).ToHashSet();
        var defaultArmours = model.AvailableArmours
            .Where(a => a.Item2 == 0 && equippedArmourTypes.Contains(a.Item1))
            .Select(a => new CatalogOptionDto(a.Item1.ToString()!, a.Item1.ToNameString(), a.Item2))
            .ToList();

        var availableArmours = model.AvailableArmours
            .Where(a => a.Item2 > 0)
            .Select(a => new CatalogOptionDto(a.Item1.ToString()!, a.Item1.ToNameString(), a.Item2))
            .ToList();

        var availableSpecialRules = model.AvailableSpecialRules
            .Select(r => new CatalogOptionDto(r.Item1.ToString()!, r.Item1.ToNameString(), r.Item2))
            .ToList();

        CommandGroupDto? commandGroup = null;
        if (model.ChampionUpgradeCost.HasValue || model.StandardBearerUpgradeCost.HasValue || model.MusicianUpgradeCost.HasValue)
        {
            commandGroup = new CommandGroupDto(
                model.ChampionName,
                model.ChampionUpgradeCost,
                model.StandardBearerUpgradeCost,
                model.MusicianUpgradeCost,
                model.MagicStandardUpToPoints,
                null // ChampionMagicItemAllowance - read via reflection if needed
            );

            // Try to get ChampionMagicItemsUpToPoints
            var champMiProp = typeof(TowModel).GetProperty("ChampionMagicItemsUpToPoints",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (champMiProp != null)
            {
                var champMiValue = champMiProp.GetValue(model) as int?;
                if (champMiValue.HasValue)
                {
                    commandGroup = commandGroup with { ChampionMagicItemAllowance = champMiValue };
                }
            }
        }

        return new UnitModelCatalogDto(
            model.ModelType.ToString()!,
            model.ModelType.ToNameString(),
            slotType,
            model.PointCost,
            stats,
            model.ModelTroopType.ToNameString(),
            model.MinUnitSize,
            model.MaxUnitSize,
            defaultWeapons,
            availableWeapons,
            defaultArmours,
            availableArmours,
            availableSpecialRules,
            commandGroup
        );
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

    private static MagicItemCatalogDto MagicItemDto(TowMagicItem item, bool isFactionSpecific)
    {
        return new MagicItemCatalogDto(
            item.MagicItemType.ToString()!,
            item.MagicItemType.ToNameString(),
            item.Points,
            item.TowMagicItemCategory.ToString(),
            isFactionSpecific
        );
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

    private static Dictionary<string, Func<TowObject, TowModelCharacterMount>> GetCharacterMountFactories()
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
}
