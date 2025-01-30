using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class WarriorsOfChaosTowFaction : TowFaction
{
    public WarriorsOfChaosTowFaction()
    {
        FactionType = TowFactionType.WarriorsOfChaos;
    }
}

public class WarriorsOfChaosGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public WarriorsOfChaosGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
