using ClashBard.Tow.ClassProducer.ConsoleApp.Models;
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

    public TowBuilderArmyParser(ILogger logger)
    {
        this.logger = logger;
    }

    public void ParseArmy(string armyName)
    {
        logger.LogInformation("Parsing army");

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
                // Create class name from character id
                var className = string.Join("",
                    character.id.Split('-')
                        .Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1)));

                var sb = new StringBuilder();

                // Add using statements
                sb.AppendLine("using ClashBard.Tow.Models.Factions;");
                sb.AppendLine("using ClashBard.Tow.Models.SpecialRules;");
                sb.AppendLine("using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;");
                sb.AppendLine("using ClashBard.Tow.Models.TowTypes;");
                sb.AppendLine("using ClashBard.Tow.Models.Weapons;");
                sb.AppendLine();
                sb.AppendLine("namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters;");
                sb.AppendLine();

                // Class declaration
                sb.AppendLine($"public class {className}TowCharacter : TowCharacter");
                sb.AppendLine("{");

                // Points cost field
                sb.AppendLine($"    private static int pointsCost = {character.points};");
                sb.AppendLine();

                // Constructor
                sb.AppendLine($"    public {className}TowCharacter(TowObject owner)");
                sb.AppendLine("        :base(owner, DarkElfTowModelType." + className + ", 5, 7, 7, 4, 3, 3, 6, 4, 10, pointsCost,");
                sb.AppendLine("            TowModelTroopType.RegularInfantryCharacter, new DarkElvesTowFaction(), 25, 25,");

                // Magic item categories
                if (character.items?.Any() == true)
                {
                    var categories = character.items[0].types
                        .Select(t => $"TowMagicItemCategory.{char.ToUpper(t[0]) + t.Substring(1)}")
                        .ToList();

                    sb.AppendLine($"            new TowMagicItemCategory[] {{ {string.Join(", ", categories)} }},");
                    sb.AppendLine($"            mayBuyMagicItemsUpToPoints: {character.items[0].maxPoints})");
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
                        sb.AppendLine($"        AssignSpecialRule(new {rule}());");
                    }
                    sb.AppendLine();
                }

                // Equipment/Weapons
                if (character.equipment?.Any() == true)
                {
                    sb.AppendLine("        // weapons");
                    foreach (var equipment in character.equipment.Where(e => !e.active))
                    {
                        var weaponName = string.Join("", equipment.name_en.Split(' ').Select(s => char.ToUpper(s[0]) + s.Substring(1)));
                        sb.AppendLine($"        AvailableWeapons.Add((TowWeaponType.{weaponName}, {equipment.points}));");
                    }
                    sb.AppendLine();
                }

                // Armor
                if (character.armor?.Any() == true)
                {
                    sb.AppendLine("        // armours");
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
                    sb.AppendLine();
                }

                // Mounts
                if (character.mounts?.Any() == true)
                {
                    sb.AppendLine("        // mounts");
                    foreach (var mount in character.mounts.Where(m => !m.active))
                    {
                        var mountName = string.Join("", mount.name_en.Split(' ').Select(s => char.ToUpper(s[0]) + s.Substring(1)));
                        mountName = mountName.Split('{')[0].Trim();
                        sb.AppendLine($"        AvailableMounts.Add((DarkElfTowModelMountType.{mountName}, {mount.points}));");
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
}
