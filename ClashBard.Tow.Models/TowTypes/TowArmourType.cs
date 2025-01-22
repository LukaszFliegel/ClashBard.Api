using System.ComponentModel;
using System.Reflection;

namespace ClashBard.Tow.Models.TowTypes;

public enum TowArmourType
{
    [Description("Light Armor")]
    LightArmour = 1,
    [Description("Heavy Armor")]
    HeavyArmour = 2,
    [Description("Full Plate Armour")]
    FullPlateArmour = 3,
    [Description("Shield")]
    Shield = 4,
    [Description("Sea Dragon Cloak")]
    SeaDragonCloak = 5
}
