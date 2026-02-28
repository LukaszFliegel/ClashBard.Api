using ClashBard.Api.DTOs;
using ClashBard.Tow.Models;
using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.FactionModels.DarkElves;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.Factions.ArmyCompositions;
using ClashBard.Tow.Models.MagicItems.ArcaneItems;
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
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Api.Services;

public class DarkElvesArmyBuilderService : IArmyBuilderService
{
    public ArmyValidationResponseDto ValidateArmy(ArmyConfigurationDto config)
    {
        var army = BuildArmy(config);
        var errors = army.Validate().ToList();
        var breakdown = CalculateBreakdown(army);

        return new ArmyValidationResponseDto(
            !errors.Any(),
            army.GetTotalPoints(),
            breakdown,
            errors.Select(e => new ValidationErrorDto(e.ValidationErrorMessage, e.Owner)).ToList()
        );
    }

    public PointsBreakdownDto CalculatePoints(ArmyConfigurationDto config)
    {
        var army = BuildArmy(config);
        return CalculateBreakdown(army);
    }

    private TowArmy BuildArmy(ArmyConfigurationDto config)
    {
        var faction = new DarkElvesTowFaction();
        var army = new TowArmy(faction, config.PointsLimit, "army");
        var composition = new DarkElvesArmyComposition(army);
        army.SetArmyComposition(composition);

        var characterMap = new Dictionary<string, TowCharacter>();

        // Build characters
        foreach (var charConfig in config.Characters)
        {
            var character = CreateCharacter(charConfig.ModelTypeId, army);
            if (character == null) continue;

            characterMap[charConfig.Id] = character;

            // Set mount
            if (!string.IsNullOrEmpty(charConfig.MountId))
            {
                var mount = CreateCharacterMount(charConfig.MountId, character);
                if (mount != null) character.SetMount(mount);
            }

            // Set weapons
            foreach (var weaponId in charConfig.EquippedWeapons)
            {
                var weapon = CreateWeapon(weaponId, character);
                if (weapon != null) character.SetWeapon(weapon);
            }

            // Set armours
            foreach (var armourId in charConfig.EquippedArmours)
            {
                var armour = CreateArmour(armourId, character);
                if (armour != null) character.SetArmor(armour);
            }

            // Set special rules
            foreach (var ruleId in charConfig.EquippedSpecialRules)
            {
                var rule = CreateSpecialRule(ruleId);
                if (rule != null) character.SetSpecialRule(rule);
            }

            // Set magic items
            foreach (var magicItemId in charConfig.MagicItemIds)
            {
                var item = CreateMagicItem(magicItemId, character);
                if (item != null)
                {
                    // Special handling for faction-specific items
                    if (item is DarkElvesGiftsOfKhaine gok && character is DeathHagTowCharacter)
                    {
                        character.SetMagicItem(gok);
                    }
                    else if (item is DarkElvesForbiddenPoisons fp && character is KhainiteAssassinTowCharacter assassin)
                    {
                        assassin.SetForbiddenPoison(fp);
                    }
                    else
                    {
                        character.SetMagicItem(item);
                    }
                }
            }

            // Set magic level (mages)
            if (!string.IsNullOrEmpty(charConfig.MagicLevel) && character is TowCharacterMage mage)
            {
                if (Enum.TryParse<TowMagicLevelType>(charConfig.MagicLevel, out var level))
                {
                    try { mage.SetMagicLevel(level); } catch { }
                }
            }

            // Set magic lore (mages)
            if (!string.IsNullOrEmpty(charConfig.MagicLore) && character is TowCharacterMage mage2)
            {
                if (Enum.TryParse<TowMagicLoreType>(charConfig.MagicLore, out var lore))
                {
                    try { mage2.SetMagicLore(lore); } catch { }
                }
            }

            // BSB magic standard
            if (charConfig.IsBsb && character is TowCharacterBsb bsb && !string.IsNullOrEmpty(charConfig.MagicStandardId))
            {
                var banner = CreateMagicStandard(charConfig.MagicStandardId, bsb);
                if (banner != null)
                {
                    bsb.SetMagicStandard(banner);
                }
            }

            army.AddCharacter(character);
        }

        // Set general
        if (!string.IsNullOrEmpty(config.GeneralId) && characterMap.ContainsKey(config.GeneralId))
        {
            army.General = characterMap[config.GeneralId];
        }

        // Set BSB
        if (!string.IsNullOrEmpty(config.BsbId) && characterMap.ContainsKey(config.BsbId))
        {
            if (characterMap[config.BsbId] is TowCharacterBsb bsb)
            {
                army.BattleStandardBearer = bsb;
            }
        }

        // Build units
        foreach (var unitConfig in config.Units)
        {
            var model = CreateUnitModel(unitConfig.ModelTypeId, army);
            if (model == null) continue;

            var unit = new TowUnit(model, unitConfig.Amount, faction,
                unitConfig.HasStandard, unitConfig.HasMusician, unitConfig.HasChampion);

            // Set weapons
            foreach (var weaponId in unitConfig.EquippedWeapons)
            {
                var weapon = CreateWeapon(weaponId, unit);
                if (weapon != null) unit.SetWeapon(weapon);
            }

            // Set armours
            foreach (var armourId in unitConfig.EquippedArmours)
            {
                var armour = CreateArmour(armourId, unit);
                if (armour != null) unit.SetArmor(armour);
            }

            // Set special rules
            foreach (var ruleId in unitConfig.EquippedSpecialRules)
            {
                var rule = CreateSpecialRule(ruleId);
                if (rule != null) unit.SetSpecialRule(rule);
            }

            // Set magic standard
            if (!string.IsNullOrEmpty(unitConfig.MagicStandardId))
            {
                var banner = CreateMagicStandard(unitConfig.MagicStandardId, unit);
                if (banner != null) unit.SetMagicStandard(banner);
            }

            army.AddUnit(unit);
        }

        return army;
    }

    private PointsBreakdownDto CalculateBreakdown(TowArmy army)
    {
        int characters = 0, core = 0, special = 0, rare = 0;

        var composition = new DarkElvesArmyComposition(army);

        foreach (var ch in army.GetCharacters())
        {
            characters += ch.CalculateTotalCost();
        }

        foreach (var unit in army.GetUnits())
        {
            var slot = composition.GetSlot(unit.Model.ModelType);
            var cost = unit.CalculateTotalCost();
            switch (slot)
            {
                case TowArmySlotType.Core: core += cost; break;
                case TowArmySlotType.Special: special += cost; break;
                case TowArmySlotType.Rare: rare += cost; break;
            }
        }

        return new PointsBreakdownDto(characters, core, special, rare, army.GetTotalPoints());
    }

    // === Factory methods ===

    private static TowCharacter? CreateCharacter(string modelTypeId, TowArmy army) =>
        modelTypeId switch
        {
            "DarkElfDreadlord" => new DarkElfDreadlordTowCharacter(army),
            "DarkElfMaster" => new DarkElfMasterTowCharacter(army),
            "SupremeSorceress" => new SupremeSorceressTowCharacter(army),
            "Sorceress" => new SorceressTowCharacter(army),
            "HighBeastmaster" => new HighBeastmasterTowCharacter(army),
            "DeathHag" => new DeathHagTowCharacter(army),
            "KhainiteAssassin" => new KhainiteAssassinTowCharacter(army),
            _ => null
        };

    private static TowModel? CreateUnitModel(string modelTypeId, TowArmy army) =>
        modelTypeId switch
        {
            "DarkElfWarriors" => new DarkElfWarriorTowModel(army),
            "RepeaterCrossbowmen" => new RepeaterCrossbowmanTowModel(army),
            "BlackArkCorsairs" => new BlackArkCorsairTowModel(army),
            "DarkRiders" => new DarkRiderTowModel(army),
            "Harpies" => new HarpyTowModel(army),
            "BlackGuardOfNaggarond" => new BlackGuardOfNaggarondTowModel(army),
            "HarGanethExecutioners" => new HarGanethExecutionerTowModel(army),
            "DarkElfShades" => new DarkElfShadeTowModel(army),
            "WitchElves" => new WitchElfTowModel(army),
            "SistersOfSlaughter" => new SisterOfSlaughterTowModel(army),
            "ColdOneKnights" => new ColdOneKnightTowModel(army),
            "DoomfireWarlocks" => new DoomfireWarlockTowModel(army),
            "ColdOneChariots" => new ColdOneChariotsTowModel(army),
            "ScourgerunnerChariots" => new ScourgerunnerChariotTowModel(army),
            "BloodwrackShrine" => new BloodwrackShrineTowModel(army),
            "WarHydra" => new WarHydraTowModel(army),
            "Kharibdyss" => new KharibdyssTowModel(army),
            "ReaperBoltThrower" => new ReaperBoltThrowerTowModel(army),
            _ => null
        };

    private static TowModelCharacterMount? CreateCharacterMount(string mountId, TowObject owner) =>
        mountId switch
        {
            "DarkSteed" => new DarkSteedTowCharacterMount(owner),
            "ColdOne" => new ColdOneTowCharacterMount(owner),
            "DarkPegasus" => new DarkPegasusTowCharacterMount(owner),
            "ColdOneChariot" => new ColdOneChariotsTowCharacterMount(owner),
            "ScourgerunnerChariot" => new ScourgerunnerChariotTowCharacterMount(owner),
            "BlackDragon" => new BlackDragonTowCharacterMount(owner),
            "Manticore" => new ManticoreTowCharacterMount(owner),
            "CauldronOfBlood" => new CauldronOfBloodTowCharacterMount(owner),
            _ => null
        };

    private static TowWeapon? CreateWeapon(string weaponId, TowObject owner)
    {
        if (Enum.TryParse<TowWeaponType>(weaponId, out var weaponType))
        {
            return weaponType switch
            {
                TowWeaponType.AdditionalHandWeapon => new AdditionalHandWeaponTowWeapon(owner),
                TowWeaponType.Lance => new LanceTowWeapon(owner),
                TowWeaponType.CavalrySpear => new CavalrySpearTowWeapon(owner),
                TowWeaponType.ThrustingSpear => new ThrustingSpearTowWeapon(owner),
                TowWeaponType.RepeaterCrossbow => new RepeaterCrossbowTowWeapon(owner),
                TowWeaponType.ThrowingWeapons => new ThrowingWeaponsTowWeapon(owner),
                TowWeaponType.Halberd => new TowWeapon(owner, TowWeaponType.Halberd, 0, TowWeaponStrength.Splus1, 0),
                TowWeaponType.GreatWeapon => new TowWeapon(owner, TowWeaponType.GreatWeapon, 0, TowWeaponStrength.Splus2, 0),
                TowWeaponType.RepeaterHandbow => new TowWeapon(owner, TowWeaponType.RepeaterHandbow, 8, TowWeaponStrength.Three, 0),
                TowWeaponType.BraceOfRepeaterHandbows => new TowWeapon(owner, TowWeaponType.BraceOfRepeaterHandbows, 8, TowWeaponStrength.Three, 0),
                TowWeaponType.Crossbow => new TowWeapon(owner, TowWeaponType.Crossbow, 30, TowWeaponStrength.Four, 0),
                _ => new TowWeapon(owner, weaponType, 0, TowWeaponStrength.S, 0)
            };
        }
        return null;
    }

    private static TowArmour? CreateArmour(string armourId, TowObject owner) =>
        armourId switch
        {
            "LightArmour" => new LightArmourTowArmour(owner),
            "HeavyArmour" => new HeavyArmourTowArmour(owner),
            "FullPlateArmour" => new FullPlateArmourTowArmour(owner),
            "Shield" => new ShieldTowArmour(owner),
            _ => null
        };

    private static TowSpecialRule? CreateSpecialRule(string ruleId) =>
        ruleId switch
        {
            "SeaDragonCloak" => new ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules.SeaDragonCloak(),
            "Veteran" => new ClashBard.Tow.Models.SpecialRules.Veteran(),
            "FireAndFlee" => new ClashBard.Tow.Models.SpecialRules.FireAndFlee(),
            "Scouts" => new ClashBard.Tow.Models.SpecialRules.Scouts(),
            _ => null
        };

    private static TowMagicItem? CreateMagicItem(string itemId, TowObject owner) =>
        itemId switch
        {
            // Common Magic Weapons
            "OgreBlade" => new OgreBladeTowMagicWeapon(owner),
            "GiantBlade" => new GiantBladeTowMagicWeapon(owner),
            "SwordOfBattle" => new SwordOfBattleTowMagicWeapon(owner),
            "SwordOfMight" => new SwordOfMightTowMagicWeapon(owner),
            "SwordOfStriking" => new SwordOfStrikingTowMagicWeapon(owner),
            "SwordOfSwiftness" => new SwordOfSwiftnessTowMagicWeapon(owner),
            "DuellistsBlades" => new DuellistsBladesTowMagicWeapon(owner),
            "DragonSlayingSword" => new DragonSlayingSwordTowMagicWeapon(owner),
            "HeadsmansAxe" => new HeadsmansAxeTowMagicWeapon(owner),
            "SpelleaterAxe" => new SpelleaterAxeTowMagicWeapon(owner),
            "BerserkerBlade" => new BerserkerBladeTowMagicWeapon(owner),
            "BitingBlade" => new BitingBladeTowMagicWeapon(owner),
            "BurningBlade" => new BurningBladeTowMagicWeapon(owner),

            // Common Magic Armours
            "ArmourOfDestiny" => new ArmourOfDestinyTowMagicArmour(owner),
            "ArmourOfMeteoricIron" => new ArmourOfMeteoricIronTowMagicArmour(owner),
            "ArmourOfSilveredSteel" => new ArmourOfSilveredSteelTowMagicArmour(owner),
            "BedazzlingHelm" => new BedazzlingHelmTowMagicArmour(owner),
            "CharmedShield" => new CharmedShieldTowMagicArmour(owner),
            "EnchantedShield" => new EnchantedShieldTowMagicArmour(owner),
            "GlitteringScales" => new GlitteringScalesTowMagicArmour(owner),
            "ShieldOfTheWarriorTrue" => new ShieldOfTheWarriorTrueTowMagicArmour(owner),
            "Spellshield" => new SpellshieldTowMagicArmour(owner),

            // Common Talismans
            "Dawnstone" => new DawnstoneTowTalisman(owner),
            "TalismanOfProtection" => new TalismanOfProtectionTowTalisman(owner),
            "PaymastersCoin" => new PaymastersCoinTowTalisman(owner),
            "ObsidianLodestone" => new ObsidianLodestoneTowTalisman(owner),
            "Luckstone" => new LuckstoneTowTalisman(owner),

            // Common Enchanted Items
            "WizardingHat" => new WizardingHatTowEnchantedItem(owner),
            "FlyingCarpet" => new FlyingCarpetTowEnchantedItem(owner),
            "HealingPotion" => new HealingPotionTowEnchantedItem(owner),
            "RubyRingOfRuin" => new RubyRingOfRuinTowEnchantedItem(owner),
            "PotionOfStrength" => new PotionOfStrengthTowEnchantedItem(owner),
            "PotionOfToughness" => new PotionOfToughnessTowEnchantedItem(owner),
            "PotionOfSpeed" => new PotionOfSpeedTowEnchantedItem(owner),
            "PotionOfFoolhardiness" => new PotionOfFoolhardinessTowEnchantedItem(owner),

            // Common Arcane Items
            "FeedbackScroll" => new FeedbackScrollTowArcaneItem(owner),
            "ScrollOfTransmogrification" => new ScrollOfTransmogrificationTowArcaneItem(owner),
            "WandOfJet" => new WandOfJetTowArcaneItem(owner),
            "LoreFamiliar" => new LoreFamiliarTowArcaneItem(owner),
            "PowerScroll" => new PowerScrollTowArcaneItem(owner),
            "DispelScroll" => new DispelScrollTowArcaneItem(owner),
            "ArcaneFamiliar" => new ArcaneFamiliarTowArcaneItem(owner),
            "EarthingRod" => new EarthingRodTowArcaneItem(owner),

            // Dark Elves Gifts of Khaine
            "CryOfWar" => new CryOfWarRuneOfKhaine(owner),
            "RuneOfKhaine" => new RuneOfKhaineRuneOfKhaine(owner),
            "Witchbrew" => new WitchbrewRuneOfKhaine(owner),

            // Dark Elves Forbidden Poisons
            "BlackLotus" => new BlackLotusForbiddenPoison(owner),
            "DarkVenom" => new DarkVenomForbiddenPoison(owner),
            "Manbane" => new ManbaneForbiddenPoison(owner),

            // Dark Elves Magic Weapons
            "ExecutionersAxe" => new ExecutionersAxeTowMagicWeapon(owner),
            "SwordOfRuin" => new SwordOfRuinTowMagicWeapon(owner),
            "Lifetaker" => new LifetakerTowMagicWeapon(owner),
            "WhipOfAgony" => new WhipOfAgonyTowMagicWeapon(owner),

            // Dark Elves Magic Armours
            "ShieldOfGhrond" => new ShieldOfGhrondTowMagicArmour(owner),
            "BloodArmour" => new BloodArmourTowMagicArmour(owner),

            // Dark Elves Talismans
            "PendantOfKhaeleth" => new PendantOfKhaelethTowTalisman(owner),
            "PearlOfInfiniteBleakness" => new PearlOfInfiniteBlaknessTowTalisman(owner),

            // Dark Elves Enchanted Items
            "BlackDragonEgg" => new BlackDragonEggTowEnchantedItem(owner),
            "HydrasTooth" => new HydrasToothTowEnchantedItem(owner),
            "GuidingEye" => new GuidingEyeTowEnchantedItem(owner),

            // Dark Elves Arcane Items
            "TomeOfFurion" => new TomeOfFurionTowArcaneItem(owner),
            "FocusFamiliar" => new FocusFamiliarTowArcaneItem(owner),
            "BlackStaff" => new BlackStaffTowArcaneItem(owner),

            _ => null
        };

    private static TowMagicStandard? CreateMagicStandard(string standardId, TowObject owner) =>
        standardId switch
        {
            // Common
            "BannerOfIronResolve" => new BannerOfIronResolveTowMagicBanner(owner),
            "RazorStandard" => new RazorStandardTowMagicBanner(owner),
            "RampagingBanner" => new RampagingBannerTowMagicBanner(owner),
            "TheBlazingBanner" => new TheBlazingBannerTowMagicBanner(owner),
            "WarBanner" => new WarBannerTowMagicBanner(owner),

            // Dark Elves
            "BannerOfHarGaneth" => new BannerOfHarGanethTowMagicBanner(owner),
            "ColdBloodedBanner" => new ColdBloodedBannerTowMagicBanner(owner),
            "BannerOfNagarythe" => new BannerOfNagarytheTowMagicBanner(owner),
            "StandardOfSlaughter" => new StandardOfSlaughterTowMagicBanner(owner),

            _ => null
        };
}
