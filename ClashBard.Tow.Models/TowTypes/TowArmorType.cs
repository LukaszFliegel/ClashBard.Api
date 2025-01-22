using System.ComponentModel;
using System.Reflection;

namespace ClashBard.Tow.Models.TowTypes;

public enum TowArmorType
{
    [Description("Light Armor")]
    LightArmor = 1,
    [Description("Heavy Armor")]
    HeavyArmor = 2,
    [Description("Full Plate Armour")]
    FullPlateArmour = 3,
    [Description("Shield")]
    Shield = 4,
    [Description("Sea Dragon Cloak")]
    SeaDragonCloak = 5
}

public static class TowArmorTypeExtensions
{
    public static string ToDescriptionString(this TowArmorType armorType)
    {
        FieldInfo fi = armorType.GetType().GetField(armorType.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
        else
            return armorType.ToString();
    }
}