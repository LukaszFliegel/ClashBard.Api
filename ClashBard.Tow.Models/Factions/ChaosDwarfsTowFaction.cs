using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class ChaosDwarfsTowFaction : TowFaction
{
    public ChaosDwarfsTowFaction()
    {
        FactionType = TowFactionType.ChaosDwarfs;
    }
}

public class ChaosDwarfsGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public ChaosDwarfsGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
