using ClashBard.Tow.ClassProducer.ConsoleApp.Models;
using ClashBard.Tow.ClassProducer.ConsoleApp.WhfbAppScrapping;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.ClassProducer.ConsoleApp.ArmyParsers;

public class TowBuilderArmyParser
{
    ILogger logger;
    ArmyHtmlScrapperCharacters armyHtmlScrapperCharacters;

    public TowBuilderArmyParser(ILogger logger, ArmyHtmlScrapperCharacters armyHtmlScrapperCharacters)
    {
        this.logger = logger;
        this.armyHtmlScrapperCharacters = armyHtmlScrapperCharacters;
    }

    public async Task ParseArmy(string armyName)
    {
        logger.LogInformation("Parsing army {armyName}", armyName);

        var curatedArmyName = armyName.ToLegalClassName();

        // Read and deserialize JSON file
        var jsonContent = File.ReadAllText($"TowBuilderData/{armyName}.json");
        var armyData = JsonConvert.DeserializeObject<DarkElvesJsonModel>(jsonContent);

        if (armyData?.characters == null)
        {
            logger.LogError("Failed to load characters from JSON file");
            return;
        }

        foreach (var character in armyData.characters)
        {
            try
            {
                var characterScrappedHtmlData = await armyHtmlScrapperCharacters.ScrapeCharacterStatsHtml(character.id);

                var isMage = character.lores?.Any() == true;

                // Create class name from character id
                var className = string.Join("",
                character.id.Split('-')
                    .Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1)));

                var sb = new StringBuilder();

                // Add using statements
                sb.AppendLine("using ClashBard.Tow.Models.Factions;");
                sb.AppendLine("using ClashBard.Tow.Models.SpecialRules;");
                sb.AppendLine($"using ClashBard.Tow.Models.SpecialRules.{curatedArmyName}SpecialRules;");
                sb.AppendLine("using ClashBard.Tow.Models.SpecialRules.Interfaces;");
                sb.AppendLine("using ClashBard.Tow.Models.TowTypes;");
                sb.AppendLine("using ClashBard.Tow.Models.Weapons;");
                sb.AppendLine("using ClashBard.Tow.StaticData;");
                sb.AppendLine();
                sb.AppendLine($"namespace ClashBard.Tow.Models.FactionModels.{curatedArmyName}.Characters;");
                sb.AppendLine();

                // Class declaration
                if (isMage)
                {
                    sb.AppendLine($"public class {className}TowCharacter : TowCharacterMage");
                }
                else
                {
                    sb.AppendLine($"public class {className}TowCharacter : TowCharacter");
                }

                sb.AppendLine("{");

                // Points cost field
                sb.AppendLine($"    private static int pointsCost = {character.points};");
                sb.AppendLine();

                // Constructor
                sb.AppendLine($"    public {className}TowCharacter(TowObject owner)");

                sb.AppendLine($"        :base(owner, DarkElvesTowModelType.{className}, {string.Join(", ", characterScrappedHtmlData.Stats)}, pointsCost,");
                if (isMage)
                {
                    sb.AppendLine($"            TowModelTroopType.{GetUnitCategory(characterScrappedHtmlData)}Character, new {curatedArmyName}TowFaction(), {characterScrappedHtmlData.BaseSize.Item1}, {characterScrappedHtmlData.BaseSize.Item2}, TowMagicLevelType.Level1,");
                }
                else
                {
                    sb.AppendLine($"            TowModelTroopType.{GetUnitCategory(characterScrappedHtmlData)}Character, new {curatedArmyName}TowFaction(), {characterScrappedHtmlData.BaseSize.Item1}, {characterScrappedHtmlData.BaseSize.Item2},");
                }

                if (isMage)
                {
                    sb.AppendLine($"            new TowMagicLoreType[] {{ {GetLores(character)} }},");
                }

                // Magic item categories
                if (character.items.Any())
                {
                    var categories = character.items.Where(p => p.name_en == "Magic Items").Single().types
                        .Select(t => $"TowMagicItemCategory.{GetMagicItemTypeName(t)}")
                        .ToList();

                    sb.Append($"            new TowMagicItemCategory[] {{ {string.Join(", ", categories)},");

                    // are there any other items that are NOT "Magic Items"
                    if (character.items.Where(p => p.name_en != "Magic Items").Any())
                    {
                        var otherCategories = character.items.Where(p => p.name_en != "Magic Items").Single().types
                        .Select(t => $"TowMagicItemCategory.{GetMagicItemTypeName(t)}")
                        .ToList();

                        sb.Append($" {string.Join(", ", otherCategories)}");
                    }

                    sb.AppendLine($" }},");

                    sb.AppendLine($"            mayBuyMagicItemsUpToPoints: {character.items.Where(p => p.name_en == "Magic Items").Single().maxPoints})");
                }
                else
                {
                    sb.AppendLine("            new TowMagicItemCategory[] { },");
                    sb.AppendLine("            mayBuyMagicItemsUpToPoints: 0)");
                }

                sb.AppendLine("    {");

                // Special rules
                if (!string.IsNullOrEmpty(character.specialRules?.name_en))
                {
                    sb.AppendLine("        // special rules");
                    var rules = character.specialRules.name_en.Split(',')
                        .Select(r => r.Trim().Replace("*", ""))
                        .Select(r => r.Replace(" ", ""));

                    foreach (var rule in rules)
                    {
                        sb.AppendLine($"        AssignSpecialRule(new {GetRuleName(rule)}());");
                    }
                    sb.AppendLine();
                }

                // Weapons
                sb.AppendLine("        // weapons");
                if (character.equipment?.Any() == true)
                {
                    foreach (var equipment in character.equipment)
                    {
                        var weaponName = string.Join("", equipment.name_en.Split(' ').Select(s => char.ToUpper(s[0]) + s.Substring(1)));

                        if (equipment.points == 0)
                        {
                            sb.AppendLine($"        AssignDefault(new {GetWeaponName(weaponName)}TowWeapon(this));");
                        }
                        else
                        {
                            sb.AppendLine($"        AvailableWeapons.Add((TowWeaponType.{GetWeaponName(weaponName)}, {equipment.points}));");
                        }
                    }
                }
                sb.AppendLine();

                // Armor
                sb.AppendLine("        // armours");
                if (character.armor?.Any() == true)
                {
                    var defaultArmor = character.armor.FirstOrDefault(a => a.active);
                    if (defaultArmor != null)
                    {
                        var armorName = string.Join("", defaultArmor.name_en.Split(' ').Select(s => char.ToUpper(s[0]) + s.Substring(1)));
                        sb.AppendLine($"        AssignDefault(new {armorName}TowArmour(this));");
                        sb.AppendLine();
                    }

                    foreach (var armor in character.armor.Where(a => !a.active))
                    {
                        var armorName = string.Join("", armor.name_en.Split(' ').Select(s => char.ToUpper(s[0]) + s.Substring(1)));
                        sb.AppendLine($"        AvailableArmours.Add((TowArmourType.{armorName}, {armor.points}));");
                    }
                }
                sb.AppendLine();

                // Mounts
                if (character.mounts?.Any() == true)
                {
                    sb.AppendLine("        // mounts");
                    foreach (var mount in character.mounts.Where(m => !m.active))
                    {
                        var mountName = string.Join("", mount.name_en.Split(' ').Select(s => char.ToUpper(s[0]) + s.Substring(1)));
                        mountName = mountName.Split('{')[0].Trim();
                        sb.AppendLine($"        AvailableMounts.Add(({curatedArmyName}TowModelMountType.{mountName}, {mount.points}));");
                    }
                    sb.AppendLine();
                }

                sb.AppendLine("    }");
                sb.AppendLine("}");

                // check if TowBuilderData/ProducedClasses/{armyName} directory exists, if not create it
                var armyProducedClassesDirectory = $"TowBuilderData/ProducedClasses/{armyName}";
                if (!Directory.Exists(armyProducedClassesDirectory))
                {
                    Directory.CreateDirectory(armyProducedClassesDirectory);
                }

                // check if armyProducedClassesDirectory/characters directory exists, if not create it
                var armyProducedClassesCharactersDirectory = $"{armyProducedClassesDirectory}/characters";
                if (!Directory.Exists(armyProducedClassesCharactersDirectory))
                {
                    Directory.CreateDirectory(armyProducedClassesCharactersDirectory);
                }

                // Write to file
                File.WriteAllText($"{armyProducedClassesCharactersDirectory}/{className}.cs", sb.ToString());
                logger.LogInformation($"Generated class file for {className}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error processing character {character.name_en}");
            }
        }
    }

    private static string GetLores(Character character)
    {
        var lores = character.lores;
        return string.Join(", ", lores.Select(p => $"TowMagicLoreType.{p.ToLegalClassName()}"));
    }

    private static string GetUnitCategory(ScrappedCharacter characterScrappedHtmlData)
    {
        switch(characterScrappedHtmlData.UnitCategory)
        {
            case "Regular Infantry":
                return "RegularInfantry";
        }

        throw new Exception("Unknown unit category");
    }

    private static string GetMagicItemTypeName(string t)
    {
        if (t == "weapons" || t == "weapon")
        {
            return "MagicWeapons";
        }

        if(t == "armour" || t == "armor")
        {
            return "MagicArmour";
        }

        if(t == "talisman")
        {
            return "Talisman";
        }

        if (t == "enchanteditem" || t == "enchanted-item")
        {
            return "EnchantedItem";
        }

        if (t == "arcaneitem" || t == "arcane-item")
        {
            return "Arcane";
        }

        if (t == "armor-mages")
        {
            return string.Empty; // ?
        }

        // Dark Elves
        if (t == "giftofkhaine")
        {
            return "GiftsOfKhaine";
        }

        //return t.ToLegalClassName();
        throw new Exception("Unknown magic item type");
    }

    private static string GetRuleName(string rule)
    {
        return rule.Trim().Replace("*", string.Empty).Replace("'", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
    }

    private static string GetWeaponName(string weaponName)
    {
        if(weaponName == "TwoHandWeapons")
        {
            return "AdditionalHandWeapon";
        }


        return weaponName;
    }
}
