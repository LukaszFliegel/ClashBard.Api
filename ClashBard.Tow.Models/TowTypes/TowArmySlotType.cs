using System.ComponentModel;

namespace ClashBard.Tow.Models.TowTypes;

public enum TowArmySlotType
{
    [Description("Characters")]
    Characters = 1,
    [Description("Core")]
    Core,
    [Description("Special")]
    Special,
    [Description("Rare")]
    Rare,
}
