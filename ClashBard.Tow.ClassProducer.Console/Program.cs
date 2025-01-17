// See https://aka.ms/new-console-template for more information
using ClashBard.Tow.ClassProducer.Console.Models;
using Newtonsoft.Json;

Console.WriteLine("Old World Builder json parser");

// serialize magic-items.sjon file into TowBuilderMagicItems class
var magicItems = JsonConvert.DeserializeObject<TowBuilderMagicItems>(File.ReadAllText("TowBuilderData\\magic-items.json"));


foreach (var magicItem in magicItems.general)
{
    // create file for each magic item
    var parsedName = magicItem.name_en.Replace(" ", string.Empty).Replace("'", string.Empty).Replace("*", string.Empty);
    var magicItemFile = new FileInfo($"TowBuilderData\\ProducedClasses\\{parsedName}.cs");


    // TODO: finish this console app for creating classes
    // write into that file
    using (var writer = magicItemFile.CreateText())
    {
        switch (magicItem.type)
        {
            case "weapon":
                writer.Write(
$@"
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class {magicItem.name_en.ToLegalClassName()} : TowMagicWeapon
{{
    private const int points = {magicItem.points}

    public OgreBlade() : base(TowMagicItemWeaponType.OgreBlade, points, 0, TowWeaponStrength.Splus2, 2)
    {{
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new MultipleWoundsD3());
    }}
}}
"
                    );
            break;
        }

        //writer.WriteLine("using ClashBard.Tow.Models;");
        //writer.WriteLine("using ClashBard.Tow.Models.MagicItems;");
        //writer.WriteLine("using ClashBard.Tow.Models.TowTypes;");
        //writer.WriteLine("using System;");
        //writer.WriteLine();
        //writer.WriteLine($"namespace ClashBard.Tow.Models.MagicItems");
        //writer.WriteLine("{");
        //writer.WriteLine($"    public class {parsedName}TowMagicItem : MagicItem");
        //writer.WriteLine("    {");
        //writer.WriteLine($"        public {parsedName}TowMagicItem()");
        //writer.WriteLine("        {");
        //writer.WriteLine($"            Name = \"{magicItem.name_en}\";");
        //writer.WriteLine($"            Description = \"{magicItem.name_en}\";");
        //writer.WriteLine($"            PointCost = {magicItem.points};");
        //writer.WriteLine($"            MagicItemType = MagicItemType.{magicItem.type};");
        //writer.WriteLine("        }");
        //writer.WriteLine("    }");
        //writer.WriteLine("}");
    }
}