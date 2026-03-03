using ClashBard.Api.DTOs;
using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;

namespace ClashBard.Api.Services;

/// <summary>
/// Shared extraction helpers for building faction catalogs.
/// Faction-specific providers inherit from this to avoid duplicating
/// character, unit, mount, and magic-item extraction logic.
/// </summary>
public abstract class FactionCatalogProviderBase : IFactionCatalogProvider
{
    public abstract TowFactionType FactionType { get; }
    public abstract FactionCatalogDto BuildCatalog();

    // ─── Character extraction ───────────────────────────────────────

    protected CharacterCatalogDto ExtractCharacter(TowCharacter character)
    {
        var stats = new ModelStatsDto(
            character.Movement, character.WeaponSkill, character.BallisticSkill,
            character.Strength, character.Toughness, character.Wounds,
            character.Initiative, character.Attacks, character.Leadership
        );

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

        var defaultSpecialRules = character.GetSpecialRules()
            .Where(r => r.PrintInSummary)
            .Select(r => new CatalogOptionDto(r.RuleType.ToString()!, r.RuleType.ToNameString(), 0))
            .ToList();

        var availableMounts = ExtractMounts(character);
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
            character.BaseSizeWidth,
            character.BaseSizeLength,
            defaultWeapons,
            availableWeapons,
            defaultArmours,
            availableArmours,
            defaultSpecialRules,
            availableSpecialRules,
            availableMounts,
            availableMagicItemCategories,
            character.MayBuyMagicItemsUpToPoints,
            mageInfo,
            bsbInfo
        );
    }

    // ─── Mount extraction ───────────────────────────────────────────

    /// <summary>
    /// Override in faction providers to supply the mount factories
    /// mapping mount-type ID strings to factory functions.
    /// </summary>
    protected virtual Dictionary<string, Func<TowObject, TowModelCharacterMount>> GetCharacterMountFactories()
        => new();

    protected IReadOnlyList<MountCatalogDto> ExtractMounts(TowCharacter character)
    {
        var mounts = new List<MountCatalogDto>();
        var mountFactories = GetCharacterMountFactories();

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

    // ─── Magic item categories ──────────────────────────────────────

    protected List<string> GetAvailableMagicItemCategories(TowCharacter character)
    {
        var field = typeof(TowCharacter).GetField("AvailableMagicItemTypes",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        if (field?.GetValue(character) is ICollection<TowMagicItemCategory> categories)
        {
            return categories.Select(c => c.ToString()!).ToList();
        }

        return new List<string>();
    }

    // ─── Mage / BSB info ────────────────────────────────────────────

    protected MageInfoDto ExtractMageInfo(TowCharacterMage mage)
    {
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

    protected BsbInfoDto ExtractBsbInfo(TowCharacterBsb bsb)
    {
        var upgradeCostField = typeof(TowCharacterBsb).GetField("battleStandardBearerUpgradeCost",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        int upgradeCost = (int)(upgradeCostField?.GetValue(bsb) ?? 0);

        var magicStdField = typeof(TowCharacterBsb).GetField("magicStandardUpToPoints",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        int magicStdAllowance = (int)(magicStdField?.GetValue(bsb) ?? 0);

        return new BsbInfoDto(upgradeCost, magicStdAllowance);
    }

    // ─── Unit extraction ────────────────────────────────────────────

    protected UnitModelCatalogDto ExtractUnit(TowModel model, string slotType)
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

        var defaultSpecialRules = model.GetSpecialRules()
            .Where(r => r.PrintInSummary)
            .Select(r => new CatalogOptionDto(r.RuleType.ToString()!, r.RuleType.ToNameString(), 0))
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
                null,
                null
            );

            var champMiProp = typeof(TowModel).GetProperty("ChampionMagicItemsUpToPoints",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (champMiProp != null)
            {
                var champMiValue = champMiProp.GetValue(model) as int?;
                if (champMiValue.HasValue)
                {
                    var champCategories = new List<string>
                    {
                        TowMagicItemCategory.MagicWeapon.ToString(),
                        TowMagicItemCategory.MagicArmour.ToString(),
                        TowMagicItemCategory.EnchantedItem.ToString(),
                        TowMagicItemCategory.Talisman.ToString(),
                    };
                    commandGroup = commandGroup with
                    {
                        ChampionMagicItemAllowance = champMiValue,
                        ChampionMagicItemCategories = champCategories
                    };
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
            model.BaseSizeWidth,
            model.BaseSizeLength,
            defaultWeapons,
            availableWeapons,
            defaultArmours,
            availableArmours,
            defaultSpecialRules,
            availableSpecialRules,
            commandGroup
        );
    }

    // ─── Magic item DTO helper ──────────────────────────────────────

    protected static MagicItemCatalogDto MagicItemDto(TowMagicItem item, bool isFactionSpecific)
    {
        return new MagicItemCatalogDto(
            item.MagicItemType.ToString()!,
            item.MagicItemType.ToNameString(),
            item.Points,
            item.TowMagicItemCategory.ToString(),
            isFactionSpecific
        );
    }
}
