// See https://aka.ms/new-console-template for more information
using ClashBard.Tow.ClassProducer.Console.Models;
using Newtonsoft.Json;

Console.WriteLine("Old World Builder json parser");

// serialize magic-items.sjon file into TowBuilderMagicItems class
var magicItems = JsonConvert.DeserializeObject<TowBuilderMagicItems>(File.ReadAllText("TowBuilderData\\magic-items.json"));

if (magicItems == null)
{
    Console.WriteLine("Failed to deserialize magic-items.json file");
    return;
}

// if folder TowBuilderData\\ProducedClasses does not exists create it
var producedClassesDir = "TowBuilderData\\ProducedClasses";
if (!Directory.Exists(producedClassesDir))
{
    Directory.CreateDirectory(producedClassesDir);
}

var subDirectories = new[] { "weapon", "armor", "talisman", "banner", "enchanted-item", "arcane-item" };

foreach (var subDir in subDirectories)
{
    var fullPath = Path.Combine(producedClassesDir, subDir);
    if (!Directory.Exists(fullPath))
    {
        Directory.CreateDirectory(fullPath);
    }
}

foreach (var magicItem in magicItems.general)
{
    var parsedName = magicItem.name_en.ToLegalClassName();
    var magicItemFile = new FileInfo($"TowBuilderData\\ProducedClasses\\{magicItem.type}\\{parsedName}_produced.cs");

    using (var writer = magicItemFile.CreateText())
    {
        //Console.WriteLine($"Creating a class for {magicItem.name_en}");

        switch (magicItem.type)
        {
            case "weapon":
                writer.Write(
$@"using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class {magicItem.name_en.ToLegalClassName()}TowMagicWeapon : TowMagicWeapon
{{
    private const int points = {magicItem.points};

    public {magicItem.name_en.ToLegalClassName()}() : base(TowMagicItemWeaponType.{magicItem.name_en.ToLegalClassName()}, points, 999, TowWeaponStrength.Unknown, 777)
    {{
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }}
}}
"
                    );

                //Console.WriteLine($"TowMagicItemWeaponType to create {magicItem.name_en.ToLegalClassName()}");

                break;

            case "armor":
                writer.Write(
$@"using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class {magicItem.name_en.ToLegalClassName()}TowMagicArmour : TowMagicArmour
{{
    private const int points = {magicItem.points};

    public {magicItem.name_en.ToLegalClassName()}() : base(TowMagicItemArmorType.{magicItem.name_en.ToLegalClassName()}, points, 999)
    {{
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }}
}}
"
                    );

                //Console.WriteLine($"TowMagicItemArmorType to create {magicItem.name_en.ToLegalClassName()}");

                break;

            case "talisman":
                writer.Write(
$@"using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class {magicItem.name_en.ToLegalClassName()}TowTalisman : TowTalisman
{{
    private const int points = {magicItem.points};

    public {magicItem.name_en.ToLegalClassName()}() : base(TowMagicItemTalismanType.{magicItem.name_en.ToLegalClassName()}, points)
    {{
        SpecialRules.Add(new {magicItem.name_en.ToLegalClassName()}Rules());
    }}
}}


public class {magicItem.name_en.ToLegalClassName()}Rules : TowSpecialRule
{{
    private static string ShortDescription = ""xxx"";
    private static string LongDescription = ""xxx"";

    public {magicItem.name_en.ToLegalClassName()}Rules()
        : base(TowSpecialRuleType.{magicItem.name_en.ToLegalClassName()}Rules,
            ShortDescription,
            LongDescription,
            printName: false)
    {{

    }}
}}
"
                    );

                //Console.WriteLine($"TowMagicItemTalismanType to create {magicItem.name_en.ToLegalClassName()}");

                break;

            case "banner":
                writer.Write(
$@"using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class {magicItem.name_en.ToLegalClassName()}TowMagicBanner : TowMagicBanner
{{
    private const int points = {magicItem.points};


    public {magicItem.name_en.ToLegalClassName()}() : base(TowMagicItemBannerType.{magicItem.name_en.ToLegalClassName()}, points)
    {{
        SpecialRules.Add(new {magicItem.name_en.ToLegalClassName()}Rules());
    }}
}}


public class {magicItem.name_en.ToLegalClassName()}Rules : TowSpecialRule
{{
    private static string ShortDescription = ""Gives unit Stubborn"";
    private static string LongDescription = ""A unit carrying the Banner of Iron Resolve gains the Stubborn special rule."";

    public {magicItem.name_en.ToLegalClassName()}Rules()
        : base(TowSpecialRuleType.{magicItem.name_en.ToLegalClassName()}Rules,
            ShortDescription,
            LongDescription,
            printName: false)
    {{

    }}
}}

");

                //Console.WriteLine($"TowMagicItemBannerType to create {magicItem.name_en.ToLegalClassName()}");

                break;
            case "enchanted-item":
                writer.Write(
$@"using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class {magicItem.name_en.ToLegalClassName()}TowEnchantedItem : TowEnchantedItem
{{
    private const int points = {magicItem.points};
    

    public {magicItem.name_en.ToLegalClassName()}() : base(TowMagicItemEnchantedType.{magicItem.name_en.ToLegalClassName()}, points)
    {{
        SpecialRules.Add(new {magicItem.name_en.ToLegalClassName()}Rules());
        
    }}
}}


public class {magicItem.name_en.ToLegalClassName()}Rules : TowSpecialRule
{{
    private static string ShortDescription = ""xxx"";
    private static string LongDescription = ""xxx"";

    public {magicItem.name_en.ToLegalClassName()}Rules()
        : base(TowSpecialRuleType.{magicItem.name_en.ToLegalClassName()}Rules,
            ShortDescription,
            LongDescription,
            printName: false)
    {{

    }}
}}
");
                //Console.WriteLine($"TowMagicItemEnchantedType to create {magicItem.name_en.ToLegalClassName()}");

                break;
            case "arcane-item":
                writer.Write(
$@"using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class {magicItem.name_en.ToLegalClassName()}TowArcaneItem : TowArcaneItem
{{
    private const int points = {magicItem.points};

    public {magicItem.name_en.ToLegalClassName()}() : base(TowMagicItemArcaneType.{magicItem.name_en.ToLegalClassName()}, points)
    {{
        SpecialRules.Add(new {magicItem.name_en.ToLegalClassName()}Rules());
    }}
}}


public class {magicItem.name_en.ToLegalClassName()}Rules : TowSpecialRule
{{
    private static string ShortDescription = ""xxx"";
    private static string LongDescription = ""xxx"";

    public {magicItem.name_en.ToLegalClassName()}Rules()
        : base(TowSpecialRuleType.{magicItem.name_en.ToLegalClassName()}Rules,
            ShortDescription,
            LongDescription,
            printName: false)
    {{

    }}
}}
");
                //Console.WriteLine($"TowMagicItemArcaneType to create {magicItem.name_en.ToLegalClassName()}");

                break;
            default:
                Console.WriteLine($"Unknown magic item type: {magicItem.type}");
                break;
        }

        Console.WriteLine($"TowSpecialRuleType to create: {magicItem.name_en.ToLegalClassName()}Rules");
    }
}