using System.ComponentModel;

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
